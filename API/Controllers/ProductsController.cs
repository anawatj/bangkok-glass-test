using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Dtos;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public ActionResult GetAllProduct()
        {
            try
            {
                var products = productService.GetListProduct();
                return Ok(products);
            }catch(Exception ex)
            {
                JsonResult result = new JsonResult(ex.Message);
                result.StatusCode = 500;
                return result;
            }
        }
        [HttpPost]
        public ActionResult CreateProduct(ProductDto input)
        {
            try
            {
                var data = productService.CreateProduct(input);
                JsonResult result = new JsonResult(data);
                result.StatusCode = 201;
                return result;
            }
            catch (Exception ex)
            {
                JsonResult result = new JsonResult(ex.Message);
                result.StatusCode = 400;
                return result;
            }
        }
        [Route("{id}")]
        [HttpGet]
        public ActionResult GetProductById(string id)
        {
            try
            {
                var data = productService.GetProductById(id);
                JsonResult result = new JsonResult(data);
                result.StatusCode = 200;
                return result;
            }
            catch (Exception ex)
            {
                JsonResult result = new JsonResult(ex.Message);
                result.StatusCode = 500;
                return result;
            }
        }
        [Route("{id}")]
        [HttpPut]
        public ActionResult UpdateProduct(string id,ProductDto input)
        {
            try
            {
                var data = productService.UpdateProduct(id, input);
                JsonResult result = new JsonResult(data);
                result.StatusCode = 200;
                return result;
            }
            catch (Exception ex)
            {
                JsonResult result = new JsonResult(ex.Message);
                result.StatusCode = 400;
                return result;
            }
        }
        [Route("{id}")]
        [HttpDelete]
        public ActionResult DeleteProduct(string id)
        {
            try
            {
                productService.DeleteProduct(id);
                JsonResult result = new JsonResult("Success");
                result.StatusCode = 200;
                return result;
            }
            catch (Exception ex)
            {
                JsonResult result = new JsonResult(ex.Message);
                result.StatusCode = 500;
                return result;
            }
        }
    }
}
