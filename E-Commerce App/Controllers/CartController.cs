using E_Commerce_App.DTOs;
using E_Commerce_App.DTOs.CartDTO;
using E_Commerce_App.Models;
using E_Commerce_App.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce_App.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cart;
        public CartController(ICartService cart)
        {
            _cart = cart;
        }
        [HttpGet]
        public IActionResult GetCart()
        {
            var userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(_cart.GetCart(userid));
        }
        [HttpPost]
        public IActionResult AddToCart(AddToCartDTO dto)
        {
            var userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _cart.AddToCart(userid, dto);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateQuantity(UpdateQuantityDTO dto)
        {
            var userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _cart.UpdateQuantity(userid, dto);  
            return Ok();    
        }
        [HttpDelete]
        public IActionResult RemoveFromCart( RemoveFromCartDTO dto)
        {
            var userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _cart.RemoveFromCart(userid, dto);
            return Ok();
        }
    }
}
