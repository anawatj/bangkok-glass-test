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
    public class CommonService : ICommonService
    {
        private ApplicationDbContext db;
        private IMapper mapper;
        private IRegionRepository regionRepository;
        private ICityRepository cityRepository;
        private ICategoryRepository categoryRepository;
        private IProductRepository productRepository;

        public CommonService(
            ApplicationDbContext db,
            IMapper mapper,
            IRegionRepository regionRepository,
            ICityRepository cityRepository,
            ICategoryRepository categoryRepository,
            IProductRepository productRepository)
        {
            this.db = db;
            this.mapper = mapper;
            this.regionRepository = regionRepository;
            this.cityRepository = cityRepository;
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }
        public List<SelectItemDto> GetCategories()
        {
            var categories = this.categoryRepository.FindAll();
            return categories.Select(t => mapper.Map<Category, SelectItemDto>(t)).ToList();
        }

        public List<SelectItemDto> GetCities(string regionId)
        {
            var cities = this.cityRepository.FindByRegion(regionId);
            return cities.Select(t => mapper.Map<City, SelectItemDto>(t)).ToList();
        }

        public List<SelectItemDto> GetProducts(string categoryId)
        {
            var products = this.productRepository.FindByCategory(categoryId);
            return products.Select(t => mapper.Map<Product, SelectItemDto>(t)).ToList();
        }

        public List<SelectItemDto> GetRegions()
        {
            var regions = this.regionRepository.FindAll();
            return regions.Select(t => mapper.Map<Region, SelectItemDto>(t)).ToList();
        }
    }
}
