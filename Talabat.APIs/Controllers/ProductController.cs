﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public ProductController(IGenaricRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var Spec = new ProductBrandCategorySpecifications();

            var products = await _productRepo.GetAllWithSpecAsync(Spec);

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
