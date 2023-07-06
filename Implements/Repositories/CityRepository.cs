using Core.Domains;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implements.Repositories
{
    public class CityRepository : ICityRepository
    {

        private ApplicationDbContext db;
        public CityRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public City Add(City entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<City> FindAll()
        {
            throw new NotImplementedException();
        }

        public City FindById(string id)
        {
            return this.db.Cities.Where(t => t.Id == id).FirstOrDefault();
        }

        public List<City> FindByRegion(string regionId)
        {
            var cities = this.db.Cities.Where(t => t.RegionId == regionId).ToList();
            return cities;
        }

        public City Update(City entity, string id)
        {
            throw new NotImplementedException();
        }
    }
}
