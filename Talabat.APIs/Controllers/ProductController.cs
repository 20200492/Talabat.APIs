using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Controllers.Errors;
using Talabat.APIs.Dtos;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contruct;
using Talabat.Core.Specification;
using Talabat.Core.Specification.Products_Spec;
using Talabat.Repository;

namespace Talabat.APIs.Controllers
{
    public class ProductController : BaseAPIController
    {
        private readonly IGenaricRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public ProductController(IGenaricRepository<Product> productRepo,IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts()
        {
            var Spec = new ProductBrandCategorySpecifications();

            var products = await _productRepo.GetAllWithSpecAsync(Spec);

            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var Spec = new ProductBrandCategorySpecifications(id);

            var product = await _productRepo.GetWithSpecAsync(id, Spec);

            if (product is null)
                return NotFound(new ApiResponse(404)); // 404

            return Ok(_mapper.Map<Product,ProductToReturnDto>(product)); // 200
        }
    } 
}
