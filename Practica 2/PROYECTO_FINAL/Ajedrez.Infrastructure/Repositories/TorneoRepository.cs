using Ajedrez.Domain.Entities;
using Ajedrez.Infrastructure.Context;
using Ajedrez.Infrastructure.Repositories.Interfaces;

namespace Ajedrez.Infrastructure.Repositories
{
    public class TorneoRepository : Repository<Torneo>, ITorneoRepository
    {
        public TorneoRepository(AppDbContext context) : base(context)
        {
        }
    }
}