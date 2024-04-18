using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specification.Products_Spec
{
    public class ProductBrandCategorySpecifications : BaseSpecifications<Product>
    {
        public ProductBrandCategorySpecifications() :base()
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);
        }
    }
}
