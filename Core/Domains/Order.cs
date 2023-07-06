using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class Order : BaseDomain<String>
    {
        public DateTime OrderDate { get; set; }

        public Region Region { get; set; }
        public string RegionId { get; set; }

        public City City { get; set; }

        public string CityId { get; set; }

        public Category Category { get; set; }

        public string CategoryId { get; set; }

        public Product Product { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }

        

        public decimal TotalPrice { get; set; }
    }
}
