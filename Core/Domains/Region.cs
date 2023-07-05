using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class Region : BaseDomain<String>
    {
        public string RegionName { get; set; }

        public IList<City> Cities { get; set; }

        public IList<Order> Orders { get; set; }
    }
}
