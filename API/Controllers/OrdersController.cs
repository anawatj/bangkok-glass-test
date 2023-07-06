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

        [HttpGet]
        public ActionResult GetAllOrder([FromQuery] OrderSearchDto search)
        {
            try
            {
               var orders = orderService.SearchOrder(search);
                return Ok(orders);
            }catch(Exception ex)
            {
                var data = new JsonResult(ex.Message);
                data.StatusCode = 500;
                return data;
            }
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
                result.StatusCode = 500;
                return result;
            }
        }

        [Route("{id}")]
        [HttpPut]
        public ActionResult UpdateOrder(string id,OrderDto input)
        {
            try
            {
                var result = orderService.UpdateOrder(id, input);
                var data = new JsonResult(result);
                data.StatusCode = 200;
                return data;
            }
            catch (Exception ex)
            {
                var data = new JsonResult(ex.Message);
                data.StatusCode = 400;
                return data;
            }
        }
        [Route("{id}")]
        [HttpDelete]
        public ActionResult DeleteOrder(string id)
        {
            try
            {
                orderService.DeleteOrder(id);
                var data = new JsonResult("Success");
                data.StatusCode = 200;
                return data;
            }
            catch (Exception ex)
            {
                var data = new JsonResult(ex.Message);
                data.StatusCode = 400;
                return data;
            }
        }
    }
}
