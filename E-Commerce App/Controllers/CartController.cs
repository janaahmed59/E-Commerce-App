using E_Commerce_App.DTOs;
using E_Commerce_App.DTOs.CartDTO;
using E_Commerce_App.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_App.Controllers
{
    [Route("api/[controller]")]
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
            return Ok(_cart.GetCart());
        }
        [HttpPost]
        public IActionResult AddToCart(int userid,AddToCartDTO dto)
        {
            _cart.AddToCart(userid, dto);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateQuantity(int userid, UpdateQuantityDTO dto)
        {
            _cart.UpdateQuantity(userid, dto);  
            return Ok();    
        }
        [HttpDelete]
        public IActionResult RemoveFromCart(int userid, RemoveFromCartDTO dto)
        {
            _cart.RemoveFromCart(userid, dto);
            return Ok();
        }
    }
}
