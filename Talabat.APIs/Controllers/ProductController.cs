using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Dtos;
using Talabat.APIs.Errors;
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
        private readonly IGenaricRepository<ProductBrand> _brandRepo;
        private readonly IGenaricRepository<ProductCategory> _categoryRepo;

        public ProductController(IGenaricRepository<Product> productRepo, IMapper mapper
                                , IGenaricRepository<ProductBrand> brandRepo, IGenaricRepository<ProductCategory> categoryRepo)
        {
            _productRepo = productRepo;
            _mapper = mapper;
            _brandRepo = brandRepo;
            _categoryRepo = categoryRepo;
        }

        [HttpGet()]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts(string sort)
        {
            var Spec = new ProductBrandCategorySpecifications(sort);

            var products = await _productRepo.GetAllWithSpecAsync(Spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var Spec = new ProductBrandCategorySpecifications(id);

            var product = await _productRepo.GetWithSpecAsync(id, Spec);

            if (product is null)
                return NotFound(new ApiResponse(404)); // 404

            return Ok(_mapper.Map<Product, ProductToReturnDto>(product)); // 200
        }

        [HttpGet("Brands")] // GET: api/Product/Brands
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>>GetAllBrands()
        {
            var brands = await _brandRepo.GetAllAsync();
            return Ok(brands);
        }

        [HttpGet("Categories")] // GET: api/Product/Categories
        public async Task<ActionResult<IReadOnlyList<ProductCategory>>> GetAllCategories()
        {
            var categories = await _categoryRepo.GetAllAsync();
            return Ok(categories);
        }

    } 
}
