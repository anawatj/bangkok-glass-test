using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public enum OrderSortBy
    {
        OrderDate=1,
        Region=2,
        City=3,
        Category=4,
        Product=5,
        Quantity=6,
        UnitPrice=7,
        TotalPrice=8
    }
    public enum OrderSortType
    {
        ASC=1,
        DESC=2
    }
    public class OrderSearchDto
    {
        public DateTime? OrderDateStart { get; set; }

        public DateTime? OrderDateEnd { get; set; }


        public string? Region { get; set; }

        public string? City { get; set; }

        public string? Category { get; set; }

        public string? Product { get; set; }

        public int? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TotalPrice { get; set; }

        public OrderSortBy? OrderSortBy { get; set; }

        public OrderSortType? OrderSortType { get; set; }

        
    }
}
