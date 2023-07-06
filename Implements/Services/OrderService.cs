using AutoMapper;
using Core.Domains;
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
        private IRegionRepository regionRepository;
        private ICityRepository cityRepository;
        private ICategoryRepository categoryRepository;
        private IProductRepository productRepository;
        public OrderService(
             ApplicationDbContext db,
             IMapper mapper,
             IOrderRepository orderRepository,
             IRegionRepository regionRepository,
             ICityRepository cityRepository,
             ICategoryRepository categoryRepository,
             IProductRepository productRepository)
        {
            this.db = db;
            this.mapper = mapper;
            this.orderRepository = orderRepository;
            this.regionRepository = regionRepository;
            this.cityRepository = cityRepository;
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }
        public OrderDto CreateOrder(OrderDto input)
        {
            
            try
            {
                List<string> errors = new List<string>();
                if (string.IsNullOrEmpty(input.RegionId))
                {
                    errors.Add("Region is required");
                }
                if (string.IsNullOrEmpty(input.CityId))
                {
                    errors.Add("City is required");
                }

                if (string.IsNullOrEmpty(input.CategoryId))
                {
                    errors.Add("Category is required");
                }
                if (string.IsNullOrEmpty(input.ProductId))
                {
                    errors.Add("Product is required");
                }
                if (input.Quantity<=0)
                {
                    errors.Add("quantity is required");
                }
           

                if (input.TotalPrice <= 0)
                {
                    errors.Add(" total unit price is required");
                }
                if (errors.Count > 0)
                {
                    throw new Exception(String.Join(",", errors));
                }

                Order entity = mapper.Map<OrderDto, Order>(input);
                entity.Id = Guid.NewGuid().ToString();
                var result = orderRepository.Add(entity);
                return mapper.Map<Order,OrderDto>(result);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteOrder(string id)
        {
            try
            {
                var order = orderRepository.FindById(id);
                if(order == null)
                {
                    throw new Exception("this order not found");
                }
                orderRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderDto GetOrderById(string id)
        {
            try
            {
                var order = orderRepository.FindById(id);
                return mapper.Map<Order, OrderDto>(order);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public OrderDto UpdateOrder(string id, OrderDto input)
        {
            try
            {
                List<string> errors = new List<string>();
                if (string.IsNullOrEmpty(input.RegionId))
                {
                    errors.Add("Region is required");
                }
                if (string.IsNullOrEmpty(input.CityId))
                {
                    errors.Add("City is required");
                }

                if (string.IsNullOrEmpty(input.CategoryId))
                {
                    errors.Add("Category is required");
                }
                if (string.IsNullOrEmpty(input.ProductId))
                {
                    errors.Add("Product is required");
                }
                if (input.Quantity <= 0)
                {
                    errors.Add("quantity is required");
                }
              

                if (input.TotalPrice <= 0)
                {
                    errors.Add(" total unit price is required");
                }
                if (errors.Count > 0)
                {
                    throw new Exception(String.Join(",", errors));
                }
               
                Order data = orderRepository.FindById(id);
                if (data == null)
                {
                    throw new Exception("this order not found");
                }
                data.OrderDate = input.OrderDate;
                data.RegionId = input.RegionId;
                data.Region = regionRepository.FindById(input.RegionId);
                data.CityId = input.CityId;
                data.City = cityRepository.FindById(input.CityId);
                data.CategoryId = input.CategoryId;
                data.Category = categoryRepository.FindById(input.CategoryId);
                data.ProductId = input.ProductId;
                data.Product = productRepository.FindById(input.ProductId);
                data.Quantity = input.Quantity;
                data.TotalPrice = input.TotalPrice;
                var result = orderRepository.Update(data, id);
                return mapper.Map<Order, OrderDto>(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
