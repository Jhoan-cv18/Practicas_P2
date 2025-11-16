using Microsoft.EntityFrameworkCore;
using ProductosApi.Models;

namespace ProductosApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Tabla Products
        public DbSet<Product> Products { get; set; }
    }
}