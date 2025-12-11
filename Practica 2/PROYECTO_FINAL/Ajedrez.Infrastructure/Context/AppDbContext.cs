using Ajedrez.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ajedrez.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Torneo> Torneos { get; set; }
    }
}