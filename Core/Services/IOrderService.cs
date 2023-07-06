using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IOrderService
    {
        OrderDto CreateOrder(OrderDto input);
        OrderDto GetOrderById(string id);

        OrderDto UpdateOrder(string id, OrderDto input);
        void DeleteOrder(string id);

        List<OrderDto> SearchOrder(OrderSearchDto input);
    }
}
