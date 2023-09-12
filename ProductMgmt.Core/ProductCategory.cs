using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMgmt.Core
{
    public class ProductCategory
    {
        public string Code { get; set; }
        public List<string> SubCategoryCodes { get; set; }
    }
}
