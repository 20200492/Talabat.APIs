using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Specification
{
    public class ProductSpecParams
    {
        public string? sort { get; set; }
        public int? brandId { get; set; }
        public int? categoryId { get; set; }
        public int PageIndex { get; set; } = 1;

        const int fixedSize = 10;
        private int pagesize;
        public int PageSize
        {
            get { return pagesize; }
            set { pagesize = value > pagesize ? value : pagesize; }
        }
    }
}
