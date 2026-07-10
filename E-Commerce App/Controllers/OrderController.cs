using E_Commerce_App.DTOs.OrderDTO;
using E_Commerce_App.Models;
using E_Commerce_App.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace E_Commerce_App.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService order)
        {
            _orderService = order;
        }
        [HttpGet("GetMyOrders")]
        public IActionResult GetMyOrders()
        {
            var userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(_orderService.GetMyOrders(userid));
        }
        [HttpGet("GetOrderDetails/{orderid}")]
        public IActionResult GetOrderDetails(int orderid)
        {
            var userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(_orderService.GetOrderById(orderid, userid));
        }
        [HttpGet("GetAllOrders")]
        [Authorize (Roles = "Admin")]
        public IActionResult GetAllOrders()
        {
            return Ok(_orderService.GetAllOrders());
        }
        [HttpPost("PlaceOrder")]
        public IActionResult PlaceOrder()
        {
            var userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _orderService.PlaceOrder(userid);
            return Ok("Order Created succesfully");
        }
        [HttpPut("UpdateOrderStatus/{orderid}")]
        [Authorize (Roles = "Admin")]
        public IActionResult UpdateOrderStatus(int orderid, UpdateStatusDTO dto)
        {
            var userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _orderService.UpdateOrderStatus(orderid, userid,dto);
            return NoContent();
        }
        [HttpDelete("CancelOrder/{orderid}")]
        public IActionResult CancelOrder(int orderid)
        {
            var userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _orderService.CancelOrder(orderid, userid); 
            return NoContent();
        }
    }
}
