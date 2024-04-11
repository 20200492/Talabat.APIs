using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contruct;
using Talabat.Repository;

namespace Talabat.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseAPIController
    {
        private readonly IGenaricRepository<Product> _productRepo;

        public ProductController(IGenaricRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepo.GetAllAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepo.GetAsync(id);

            if (product is null)
                return NotFound(new { StatusCode = 404, Message = "Not Found" }); // 404

            return Ok(product); // 200
        }
    }
}
