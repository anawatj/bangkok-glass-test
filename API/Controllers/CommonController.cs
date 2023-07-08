using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private ICommonService commonService;
        public CommonController(ICommonService commonService)
        {
            this.commonService = commonService;
        }
        [Route("regions")]
        [HttpGet]
        public ActionResult GetAllRegions()
        {
            try
            {
                var regions = commonService.GetRegions();
                return Ok(regions);
            }catch(Exception ex)
            {
                var result = new JsonResult(ex.Message);
                result.StatusCode = 500;
                return result;
            }
        }
        [Route("regions/{regionId}/cities")]
        [HttpGet]
        public ActionResult GetAllCities(string regionId)
        {
            try
            {
                var cities = commonService.GetCities(regionId);
                return Ok(cities);
            }catch(Exception ex)
            {
                var result = new JsonResult(ex.Message);
                result.StatusCode = 500;
                return result;
            }
        }
        [Route("categories")]
        [HttpGet]
        public ActionResult GetAllCategories()
        {
            try
            {
                var categories = commonService.GetCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                var result = new JsonResult(ex.Message);
                result.StatusCode = 500;
                return result;
            }
        }

        [Route("categories/{categoryId}/products")]
        [HttpGet]
        public ActionResult GetAllProducts(string categoryId)
        {
            try
            {
                var products = commonService.GetProducts(categoryId);
                return Ok(products);
            }
            catch (Exception ex)
            {
                var result = new JsonResult(ex.Message);
                result.StatusCode = 500;
                return result;
            }
        }
    }
}
