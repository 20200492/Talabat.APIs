using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specification.Products_Spec
{
    public class ProductBrandCategorySpecifications : BaseSpecifications<Product>
    {
        // This Constructor will be used for Creating an Object, That will be Used to Get All Productd  
        public ProductBrandCategorySpecifications(ProductSpecParams productSpecParams) 
            :base(P =>
                     (string.IsNullOrEmpty(productSpecParams.Search) || P.Name.Contains(productSpecParams.Search)) &&
                     (!productSpecParams.brandId.HasValue || P.BrandId == productSpecParams.brandId) &&
                     (!productSpecParams.categoryId.HasValue || P.CategoryId == productSpecParams.categoryId)
            )
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);

            if (!string.IsNullOrEmpty(productSpecParams.sort))
            {
                switch (productSpecParams.sort)
                {
                    case "priceAsc":
                        {
                            OrderBy = P => P.Price;
                            break;
                        }

                    case "priceDesc":
                        {
                            OrderByDesc = P => P.Price;
                            break;
                        }
                    default:
                        OrderBy = P => P.Name;
                        break;
                } 
            }
            else
                OrderBy = P => P.Name;


            ApplyPagination((productSpecParams.PageIndex - 1) * productSpecParams.PageSize, productSpecParams.PageSize);
        }

        public ProductBrandCategorySpecifications(int id) : base(P => P.Id == id)
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);
        }
    }
}
