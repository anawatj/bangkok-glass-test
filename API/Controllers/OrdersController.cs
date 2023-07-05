using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService orderService;
        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpPost]
        public ActionResult CreateOrder(OrderDto input)
        {
            try
            {
                var result = orderService.CreateOrder(input);
                var data = new JsonResult(result);
                data.StatusCode = 201;
                return data;
            }catch(Exception ex)
            {
                var data = new JsonResult(ex.Message);
                data.StatusCode = 400;
                return data;
            }
        }
        [Route("{id}")]
        [HttpGet]
        public ActionResult GetOrderById(string id)
        {
            try
            {
                var order = orderService.GetOrderById(id);
                var result = new JsonResult(order);
                result.StatusCode = 200;
                return result;
            }catch(Exception ex)
            {
                var result = new JsonResult(ex.Message);
                return result;
            }
        }
    }
}
