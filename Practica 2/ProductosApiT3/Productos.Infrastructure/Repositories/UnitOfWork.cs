using Productos.Infrastructure.Context;
using Productos.Infrastructure.Repositories;

namespace Productos.Infrastructure.UnitOfWork
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;

        public ProductRepository Products { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Products = new ProductRepository(context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
