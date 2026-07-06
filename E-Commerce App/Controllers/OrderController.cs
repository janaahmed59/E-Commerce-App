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
        [HttpGet("GetOrderDetails")]
        public IActionResult GetOrderDetails(int orderid)
        {
            return Ok(_orderService.GetOrderById(orderid));
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
