using Core.Domains;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implements.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext db;
        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Product Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Product> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<Product> FindByCategory(string categoryId)
        {
            return this.db.Products.Where(t => t.CategoryId == categoryId).ToList();
        }

        public Product FindById(string id)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product entity, string id)
        {
            throw new NotImplementedException();
        }
    }
}
