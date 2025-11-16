using Microsoft.EntityFrameworkCore;
using Productos.Domain.Entities;
using System.Collections.Generic;

namespace Productos.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}