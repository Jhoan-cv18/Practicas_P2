using Ajedrez.Domain.Entities;
using Ajedrez.Infrastructure.Context;
using Ajedrez.Infrastructure.Repositories.Interfaces;

namespace Ajedrez.Infrastructure.Repositories
{
    public class JugadorRepository : Repository<Jugador>, IJugadorRepository
    {
        public JugadorRepository(AppDbContext context) : base(context)
        {
        }
    }
}