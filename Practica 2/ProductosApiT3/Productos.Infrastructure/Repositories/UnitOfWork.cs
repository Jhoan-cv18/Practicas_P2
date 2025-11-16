using System.Threading.Tasks;
using Productos.Infrastructure.Context;

namespace Productos.Infrastructure.Repositories
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;

        // Aquí exponemos los repositorios
        public ProductRepository Products { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
        }

    }
}