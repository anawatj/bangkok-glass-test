using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class Category : BaseDomain<String>
    {
        public string CategoryName { get; set; }
        public IList<Product> Products { get; set; }

        public IList<Order> Orders { get; set; }
    }
}
