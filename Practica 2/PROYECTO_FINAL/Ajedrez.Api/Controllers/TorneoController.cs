using Ajedrez.Domain.Entities;
using Ajedrez.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ajedrez.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TorneoController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public TorneoController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/torneo
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var torneos = await _uow.Torneos.GetAllAsync();
            return Ok(torneos);
        }

        // GET: api/torneo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var torneo = await _uow.Torneos.GetByIdAsync(id);
            if (torneo == null)
                return NotFound();

            return Ok(torneo);
        }

        // POST: api/torneo
        [HttpPost]
        public async Task<IActionResult> Create(Torneo torneo)
        {
            await _uow.Torneos.AddAsync(torneo);
            await _uow.SaveAsync();

            return CreatedAtAction(nameof(Get), new { id = torneo.Id }, torneo);
        }

        // PUT: api/torneo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Torneo torneo)
        {
            var existing = await _uow.Torneos.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.Nombre = torneo.Nombre;
            existing.Fecha = torneo.Fecha;

            _uow.Torneos.Update(existing);
            await _uow.SaveAsync();

            return Ok(existing);
        }

        // DELETE: api/torneo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _uow.Torneos.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            _uow.Torneos.Delete(existing);
            await _uow.SaveAsync();

            return NoContent();
        }
    }
}