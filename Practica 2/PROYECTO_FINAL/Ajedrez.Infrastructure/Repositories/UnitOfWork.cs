using Ajedrez.Infrastructure.Context;
using Ajedrez.Infrastructure.Repositories.Interfaces;

namespace Ajedrez.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IJugadorRepository Jugadores { get; }
        public IPartidaRepository Partidas { get; }
        public ITorneoRepository Torneos { get; }

        public UnitOfWork(
            AppDbContext context,
            IJugadorRepository jugadorRepository,
            IPartidaRepository partidaRepository,
            ITorneoRepository torneoRepository)
        {
            _context = context;
            Jugadores = jugadorRepository;
            Partidas = partidaRepository;
            Torneos = torneoRepository;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}