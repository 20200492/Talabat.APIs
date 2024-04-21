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
        public ProductBrandCategorySpecifications(string sort,int? brandId, int? categoryId) 
            :base(P => 
            
                     (!brandId.HasValue || P.BrandId == brandId) &&
                     (!categoryId.HasValue || P.CategoryId == categoryId)
            )
        {
            Includes();

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
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
        }

        public ProductBrandCategorySpecifications(int id) : base(P => P.Id == id)
        {
            Includes();
        }

        private void Includes()
        {
            base.Includes.Add(P => P.Brand);
            base.Includes.Add(P => P.Category);
        }
    }
}
