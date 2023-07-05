using Core.Domains;
using Core.Repositories;
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
            throw new NotImplementedException();
        }

        public List<Order> FindAll()
        {
            throw new NotImplementedException();
        }

        public Order FindById(string id)
        {
            return this.db.Orders.Where(t => t.Id == id).FirstOrDefault();
        }

        public List<Order> Search()
        {
            throw new NotImplementedException();
        }

        public Order Update(Order entity, string id)
        {
            throw new NotImplementedException();
        }
    }
}
