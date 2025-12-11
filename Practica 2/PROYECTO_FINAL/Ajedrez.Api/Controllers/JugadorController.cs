using Ajedrez.Domain.Entities;
using Ajedrez.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ajedrez.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JugadorController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public JugadorController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/jugador
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jugadores = await _uow.Jugadores.GetAllAsync();
            return Ok(jugadores);
        }

        // GET: api/jugador/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var jugador = await _uow.Jugadores.GetByIdAsync(id);
            if (jugador == null)
                return NotFound();

            return Ok(jugador);
        }

        // POST: api/jugador
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Jugador jugador)
        {
            if (jugador == null)
                return BadRequest();

            await _uow.Jugadores.AddAsync(jugador);
            await _uow.SaveAsync();

            return CreatedAtAction(nameof(GetById), new { id = jugador.Id }, jugador);
        }

        // PUT: api/jugador/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Jugador jugador)
        {
            var existing = await _uow.Jugadores.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.Nombre = jugador.Nombre;
            existing.ELO = jugador.ELO;

            _uow.Jugadores.Update(existing);
            await _uow.SaveAsync();

            return Ok(existing);
        }

        // DELETE: api/jugador/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var jugador = await _uow.Jugadores.GetByIdAsync(id);
            if (jugador == null)
                return NotFound();

            _uow.Jugadores.Delete(jugador);
            await _uow.SaveAsync();

            return NoContent();
        }

        // GET: api/jugador/ranking
        [HttpGet("ranking")]
        public async Task<IActionResult> GetRanking()
        {
            var jugadores = await _uow.Jugadores.GetAllAsync();
            var ranking = jugadores.OrderByDescending(j => j.ELO);

            return Ok(ranking);
        }
    }
}
