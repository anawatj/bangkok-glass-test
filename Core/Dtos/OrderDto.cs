using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class OrderDto
    {
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }

        public string RegionId { get; set; }

        public string RegionName { get; set; }

        public string CityId { get; set; }
        public string CityName { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
