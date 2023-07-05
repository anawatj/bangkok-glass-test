using Core.Domains;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implements.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext db;
        public CategoryRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Category Add(Category entity)
        {
            db.Categories.Add(entity);
            return entity;
        }

        public void Delete(string id)
        {
            var deleteData = db.Categories.Where(t => t.Id == id).First();
            db.Categories.Remove(deleteData);
        }

        public List<Category> FindAll()
        {
            return db.Categories.ToList();
        }

        public Category FindById(string id)
        {
            return db.Categories.Where(t => t.Id == id).First();
        }

        public Category Update(Category entity, string id)
        {
            db.Categories.Update(entity);
            return entity;
        }
    }
}
