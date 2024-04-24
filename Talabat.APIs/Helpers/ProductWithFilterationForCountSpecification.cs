﻿using Talabat.Core.Entities;
using Talabat.Core.Specification;

namespace Talabat.APIs.Helpers
{
    public class ProductWithFilterationForCountSpecification : BaseSpecifications<Product>
    {

        public ProductWithFilterationForCountSpecification(ProductSpecParams productSpecParams) : base(P =>

                     (string.IsNullOrEmpty(productSpecParams.Search) || P.Name.Contains(productSpecParams.Search)) &&
                     (!productSpecParams.brandId.HasValue || P.BrandId == productSpecParams.brandId) &&
                     (!productSpecParams.categoryId.HasValue || P.CategoryId == productSpecParams.categoryId)
            )
        {

        }
    }
}