using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IProductService
    {
        public ProductDto CreateProduct(ProductDto input);
        public List<ProductDto> GetListProduct();

        public ProductDto GetProductById(string id);

        public ProductDto UpdateProduct(string id, ProductDto input);

        public void DeleteProduct(string id);
        
    }
}
