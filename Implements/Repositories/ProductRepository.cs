using Core.Domains;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
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
            var result = this.db.Products.Add(entity);
            this.db.SaveChanges();
            return entity;
        }

        public void Delete(string id)
        {
            var result = this.db.Products.Where(t => t.Id == id).First();
            this.db.Products.Remove(result);
            this.db.SaveChanges();
        }

        public List<Product> FindAll()
        {
            return this.db.Products.Include(t=>t.Category).ToList();
        }

        public List<Product> FindByCategory(string categoryId)
        {
            return this.db.Products.Where(t => t.CategoryId == categoryId).ToList();
        }

        public Product FindById(string id)
        {
            return this.db.Products.Where(t => t.Id == id).FirstOrDefault();
        }

        public Product Update(Product entity, string id)
        {
            this.db.Products.Update(entity);
            this.db.SaveChanges();
            return entity;
        }
    }
}
