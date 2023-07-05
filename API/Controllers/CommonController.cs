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
        public IEnumerable<SelectItemDto> GetAllRegions()
        {
            return this.commonService.GetRegions();
        }
        [Route("regions/{regionId}/cities")]
        [HttpGet]
        public IEnumerable<SelectItemDto> GetAllCities(string regionId)
        {
            return this.commonService.GetCities(regionId);
        }
        [Route("categories")]
        [HttpGet]
        public IEnumerable<SelectItemDto> GetAllCategories()
        {
            return this.commonService.GetCategories();
        }

        [Route("categories/{categoryId}/products")]
        [HttpGet]
        public IEnumerable<SelectItemDto> GetAllProducts(string categoryId)
        {
            return this.commonService.GetProducts(categoryId);
        }
    }
}
