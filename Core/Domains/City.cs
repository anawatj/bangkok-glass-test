using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class City : BaseDomain<String>
    {
        public string CityName { get; set; }
        public Region Region { get; set; }
        public string RegionId { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
