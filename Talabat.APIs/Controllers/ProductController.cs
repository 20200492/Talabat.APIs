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
    }
}
