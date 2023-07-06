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
    public class ProductService : IProductService
    {
        private ApplicationDbContext db;
        private IMapper mapper;
        private IProductRepository productRepository;
        public ProductService(
            ApplicationDbContext db,
            IMapper mapper,
            IProductRepository productRepository
            )
        {
            this.db = db;
            this.mapper = mapper;
            this.productRepository = productRepository;
        }
        public ProductDto CreateProduct(ProductDto input)
        {
            try
            {
                List<string> errors = new List<string>();
                if (string.IsNullOrEmpty(input.ProductName))
                {
                    errors.Add("Product Name is required");
                }
                if (string.IsNullOrEmpty(input.CategoryId))
                {
                    errors.Add("Category is required");
                }
                if (input.UnitPrice == 0)
                {
                    errors.Add("Unit Price is required");
                };
                if (errors.Count > 0)
                {
                    throw new Exception(string.Join(",", errors));
                }
                var product = mapper.Map<ProductDto, Product>(input);
                product.Id = Guid.NewGuid().ToString();
                productRepository.Add(product);
                return mapper.Map<Product,ProductDto>(product);
                
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteProduct(string id)
        {
            try
            {
                var product = productRepository.FindById(id);
                if (product == null)
                {
                    throw new Exception("Product is not found");
                }
                productRepository.Delete(id);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductDto> GetListProduct()
        {
            try
            {
                var products = productRepository.FindAll();

                return products.Select(t => mapper.Map<Product, ProductDto>(t)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductDto GetProductById(string id)
        {
            try
            {
                var product = productRepository.FindById(id);
                return mapper.Map<Product,ProductDto>(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductDto UpdateProduct(string id, ProductDto input)
        {
            try
            {
                List<string> errors = new List<string>();
                if (string.IsNullOrEmpty(input.ProductName))
                {
                    errors.Add("Product Name is required");
                }
                if (string.IsNullOrEmpty(input.CategoryId))
                {
                    errors.Add("Category is required");
                }
                if (input.UnitPrice == 0)
                {
                    errors.Add("Unit Price is required");
                };
                if (errors.Count > 0)
                {
                    throw new Exception(string.Join(",", errors));
                }
                var product = productRepository.FindById(id);
                if (product == null)
                {
                    throw new Exception("Product is not found");
                }
                //var product = mapper.Map<ProductDto, Product>(input);
                product.ProductName = input.ProductName;
                product.CategoryId = input.CategoryId;
                product.UnitPrice = input.UnitPrice;
                productRepository.Update(product, id);
                return mapper.Map<Product, ProductDto>(product);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
