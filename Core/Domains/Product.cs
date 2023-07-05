using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class Product : BaseDomain<String>
    {
        public string ProductName { get; set; }
        public Category Category { get; set; }
        public string CategoryId { get; set; }

        public IList<Order> Orders { get; set; }
    }
}
