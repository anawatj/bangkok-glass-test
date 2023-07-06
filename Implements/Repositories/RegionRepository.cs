using Core.Domains;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implements.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private ApplicationDbContext db;
        public RegionRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Region Add(Region entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Region> FindAll()
        {
            return this.db.Regions.ToList();
        }

        public Region FindById(string id)
        {
            return this.db.Regions.Where(t => t.Id == id).FirstOrDefault();
        }

        public Region Update(Region entity, string id)
        {
            throw new NotImplementedException();
        }
    }
}
