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

        const int MaxSize = 10;
        private int pagesize = 5;
        public int PageSize
        {
            get { return pagesize; }
            set { pagesize = value > MaxSize ? MaxSize : value; }
        }

        private string? search;

        public string? Search
        {
            get { return search; }
            set { search = value?.ToLower(); }
        }

    }
}
