using Core.Domains;
using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IOrderRepository : IRepository<Order,String>
    {
        List<Order> Search(OrderSearchDto search);
    }
}
