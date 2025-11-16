using Microsoft.AspNetCore.Mvc;
using Productos.Domain.Entities;
using Productos.Infrastructure.Repositories;
using Productos.Infrastructure.UnitOfWork;

namespace ProductosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductsController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return Ok(products);
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return product;
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }


        // PUT: api/products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest();

            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
