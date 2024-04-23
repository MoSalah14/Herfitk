using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfitk.Core.Specifications
{
    public class HerifySpecParam
    {
        public int categoryId { get; set; }

        private const int MaxPageSize = 10;
        public int? Skip { get; set; }
        public int? Take { get; set; }

        private int pageSize = 5;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }

        public int PageIndex { get; set; } = 1;
    }
}