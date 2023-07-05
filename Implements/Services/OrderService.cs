using AutoMapper;
using Core.Dtos;
using Core.Repositories;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implements.Services
{
    public class OrderService : IOrderService
    {
        private ApplicationDbContext db;
        private IMapper mapper;
        private IOrderRepository orderRepository;
        public OrderService(
             ApplicationDbContext db,
             IMapper mapper,
             IOrderRepository orderRepository)
        {
            this.db = db;
            this.mapper = mapper;
            this.orderRepository = orderRepository;
        }
        public OrderDto CreateOrder(OrderDto input)
        {
            throw new NotImplementedException();
        }
    }
}
