using Ajedrez.Domain.Entities;
using Ajedrez.Infrastructure.Context;
using Ajedrez.Infrastructure.Repositories.Interfaces;

namespace Ajedrez.Infrastructure.Repositories
{
    public class PartidaRepository : Repository<Partida>, IPartidaRepository
    {
        public PartidaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
