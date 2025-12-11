using Ajedrez.Domain.Entities;
using Ajedrez.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ajedrez.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartidaController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public PartidaController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/partida
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var partidas = await _uow.Partidas.GetAllAsync();
            return Ok(partidas);
        }

        // GET: api/partida/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var partida = await _uow.Partidas.GetByIdAsync(id);
            if (partida == null)
                return NotFound();

            return Ok(partida);
        }

        // POST: api/partida
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Partida partida)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validar jugadores
            var jugadorBlancas = await _uow.Jugadores.GetByIdAsync(partida.JugadorBlancasId);
            var jugadorNegras = await _uow.Jugadores.GetByIdAsync(partida.JugadorNegrasId);

            if (jugadorBlancas == null || jugadorNegras == null)
                return BadRequest("Uno o ambos jugadores no existen.");

            // Registrar partida
            await _uow.Partidas.AddAsync(partida);

            // Actualizar ELO según resultado
            ActualizarELO(jugadorBlancas, jugadorNegras, partida.Resultado);

            _uow.Jugadores.Update(jugadorBlancas);
            _uow.Jugadores.Update(jugadorNegras);

            await _uow.SaveAsync();

            return CreatedAtAction(nameof(GetById), new { id = partida.Id }, partida);
        }

        private void ActualizarELO(Jugador blancas, Jugador negras, Resultado resultado)
        {
            int K = 30;

            double expectedBlancas =
                1.0 / (1.0 + Math.Pow(10, (negras.ELO - blancas.ELO) / 400.0));

            double expectedNegras =
                1.0 / (1.0 + Math.Pow(10, (blancas.ELO - negras.ELO) / 400.0));

            double scoreBlancas = resultado switch
            {
                Resultado.BlancasGanan => 1,
                Resultado.NegrasGanan => 0,
                Resultado.Tablas => 0.5,
                _ => 0.5
            };

            double scoreNegras = 1 - scoreBlancas;

            blancas.ELO += (int)(K * (scoreBlancas - expectedBlancas));
            negras.ELO += (int)(K * (scoreNegras - expectedNegras));
        }

        // DELETE: api/partida/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var partida = await _uow.Partidas.GetByIdAsync(id);
            if (partida == null)
                return NotFound();

            _uow.Partidas.Delete(partida);
            await _uow.SaveAsync();

            return NoContent();
        }
    }
}