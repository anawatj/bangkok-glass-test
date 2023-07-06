using Core.Domains;
using Core.Dtos;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implements.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationDbContext db;
        public OrderRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Order Add(Order entity)
        {
            this.db.Orders.Add(entity);
            this.db.SaveChanges();
            return entity;
        }

        public void Delete(string id)
        {
            var order = this.db.Orders.Where(t => t.Id == id).First() ;
            this.db.Orders.Remove(order);
            this.db.SaveChanges();
        }

        public List<Order> FindAll()
        {
            throw new NotImplementedException();
        }

        public Order FindById(string id)
        {
            return this.db.Orders.Where(t => t.Id == id).FirstOrDefault();
        }

        public List<Order> Search(OrderSearchDto search)
        {
            var query = this.db.Orders.
                Include(t => t.Region)
                .Include(t => t.City)
                .Include(t => t.Category)
                .Include(t => t.Product).AsQueryable();
            if(search.OrderDateStart.HasValue && search.OrderDateEnd.HasValue)
            {
                query = query.Where(t => t.OrderDate >= search.OrderDateStart.Value && t.OrderDate <= search.OrderDateEnd.Value);
            }else if(search.OrderDateStart.HasValue && search.OrderDateEnd.HasValue == false)
            {
                query = query.Where(t => t.OrderDate >= search.OrderDateStart.Value);
            }else if(search.OrderDateStart.HasValue==false && search.OrderDateEnd.HasValue)
            {
                query = query.Where(t => t.OrderDate <= search.OrderDateEnd.Value);
            }

            if (!string.IsNullOrEmpty(search.Region))
            {
                query = query.Where(t => t.Region.RegionName.Contains(search.Region));
            }
            if (!string.IsNullOrEmpty(search.City))
            {
                query = query.Where(t => t.City.CityName.Contains(search.City));
            }
            if (!string.IsNullOrEmpty(search.Category))
            {
                query = query.Where(t => t.Category.CategoryName.Contains(search.Category));
            }

            if (!string.IsNullOrEmpty(search.Product))
            {
                query = query.Where(t => t.Product.ProductName.Contains(search.Product));
            }
            if (search.Quantity.HasValue)
            {
                query = query.Where(t => t.Quantity == search.Quantity.Value);
            }
            if (search.UnitPrice.HasValue)
            {
                query = query.Where(t => t.Product.UnitPrice == search.UnitPrice.Value);
            }
            if (search.TotalPrice.HasValue)
            {
                query = query.Where(t => t.TotalPrice == search.TotalPrice.Value);
            }
            if (search.OrderSortType.HasValue == false)
            {
                search.OrderSortType = OrderSortType.ASC;
            }
            if (search.OrderSortBy.HasValue)
            {
                if(search.OrderSortBy== OrderSortBy.OrderDate)
                {
                   if(search.OrderSortType== OrderSortType.ASC)
                    {
                        query = query.OrderBy(t => t.OrderDate);
                    }
                    else
                    {
                        query = query.OrderByDescending(t => t.OrderDate);
                    }

                }

                if (search.OrderSortBy == OrderSortBy.Region)
                {
                    if (search.OrderSortType == OrderSortType.ASC)
                    {
                        query = query.OrderBy(t => t.Region.RegionName);
                    }
                    else
                    {
                        query = query.OrderByDescending(t => t.Region.RegionName);
                    }

                }

                if (search.OrderSortBy == OrderSortBy.City)
                {
                    if (search.OrderSortType == OrderSortType.ASC)
                    {
                        query = query.OrderBy(t => t.City.CityName);
                    }
                    else
                    {
                        query = query.OrderByDescending(t => t.City.CityName);
                    }

                }

                if (search.OrderSortBy == OrderSortBy.Category)
                {
                    if (search.OrderSortType == OrderSortType.ASC)
                    {
                        query = query.OrderBy(t => t.Category.CategoryName);
                    }
                    else
                    {
                        query = query.OrderByDescending(t => t.Category.CategoryName);
                    }

                }

                if (search.OrderSortBy == OrderSortBy.Product)
                {
                    if (search.OrderSortType == OrderSortType.ASC)
                    {
                        query = query.OrderBy(t => t.Product.ProductName);
                    }
                    else
                    {
                        query = query.OrderByDescending(t => t.Product.ProductName);
                    }

                }
                if (search.OrderSortBy == OrderSortBy.Quantity)
                {
                    if (search.OrderSortType == OrderSortType.ASC)
                    {
                        query = query.OrderBy(t => t.Quantity);
                    }
                    else
                    {
                        query = query.OrderByDescending(t => t.Quantity);
                    }

                }

                if (search.OrderSortBy == OrderSortBy.UnitPrice)
                {
                    if (search.OrderSortType == OrderSortType.ASC)
                    {
                        query = query.OrderBy(t => t.Product.UnitPrice);
                    }
                    else
                    {
                        query = query.OrderByDescending(t => t.Product.UnitPrice);
                    }

                }

                if (search.OrderSortBy == OrderSortBy.TotalPrice)
                {
                    if (search.OrderSortType == OrderSortType.ASC)
                    {
                        query = query.OrderBy(t => t.TotalPrice);
                    }
                    else
                    {
                        query = query.OrderByDescending(t => t.TotalPrice);
                    }

                }

            }
            return query.ToList();
            

        }

        public Order Update(Order entity, string id)
        {
            this.db.Orders.Update(entity);
            this.db.SaveChanges();
            return entity;
        }
    }
}
