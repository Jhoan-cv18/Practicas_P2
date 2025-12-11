using Ajedrez.Infrastructure.Repositories.Interfaces;

namespace Ajedrez.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IJugadorRepository Jugadores { get; }
        IPartidaRepository Partidas { get; }
        ITorneoRepository Torneos { get; }

        Task<int> SaveAsync();
    }
}