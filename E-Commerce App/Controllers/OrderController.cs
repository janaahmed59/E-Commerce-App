using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Commerce_App.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using E_Commerce_App.DTOs.OrderDTO;
namespace E_Commerce_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService order)
        {
            _orderService = order;
        }
        [HttpGet("GetMyOrders")]
        public IActionResult GetMyOrders(int userid)
        {
            _orderService.GetMyOrders(userid);
            return Ok();
        }
        [HttpGet("GetOrderDetails")]
        public IActionResult GetOrderDetails(int orderid)
        {
            _orderService.GetOrderById(orderid);
            return Ok();
        }
        [HttpGet("GetAllOrders")]
        [Authorize (Roles = "Admin")]
        public IActionResult GetAllOrders()
        {
            _orderService.GetAllOrders();
            return Ok();
        }
        [HttpPost("PlaceOrder")]
        public IActionResult PlaceOrder(int userid)
        {
            _orderService.PlaceOrder(userid);
            return Ok();
        }
        [HttpPut("UpdateOrderStatus")]
        [Authorize (Roles = "Admin")]
        public IActionResult UpdateOrderStatus(int orderid, UpdateStatusDTO dto)
        {
            _orderService.UpdateOrderStatus(orderid, dto);
            return Ok();
        }
        [HttpDelete("CancelOrder")]
        public IActionResult CancelOrder(int orderid)
        {
            _orderService.CancelOrder(orderid);
            return Ok();
        }
    }
}
