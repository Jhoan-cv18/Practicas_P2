using Ajedrez.Domain.Entities; // ajusta el namespace si tu entidad está en otro
using Ajedrez.Infrastructure.Context; // ajusta el namespace de tu DbContext
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ajedrez.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PartidaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Partida
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partida>>> GetPartidas()
        {
            return await _context.Partidas.ToListAsync();
        }

        // GET: api/Partida/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Partida>> GetPartida(int id)
        {
            var partida = await _context.Partidas.FindAsync(id);

            if (partida == null)
                return NotFound();

            return partida;
        }

        // POST: api/Partida
        [HttpPost]
        public async Task<ActionResult<Partida>> PostPartida(Partida partida)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Si tu entidad tiene CreatedAt/UpdatedAt como string:
            partida.CreatedAt = DateTime.UtcNow;

            _context.Partidas.Add(partida);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPartida), new { id = partida.Id }, partida);
        }

        // PUT: api/Partida/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartida(int id, Partida partida)
        {
            if (id != partida.Id)
                return BadRequest();

            _context.Entry(partida).State = EntityState.Modified;

            try
            {
                partida.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartidaExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Partida/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartida(int id)
        {
            var partida = await _context.Partidas.FindAsync(id);
            if (partida == null)
                return NotFound();

            _context.Partidas.Remove(partida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartidaExists(int id)
        {
            return _context.Partidas.Any(e => e.Id == id);
        }
    }
}