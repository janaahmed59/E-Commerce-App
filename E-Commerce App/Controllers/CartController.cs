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
        public IActionResult AddToCart(CartitemsDTO dto)
        {
            _cart.AddToCart(dto);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateQuantity(UpdateQuantityDTO dto)
        {
            _cart.UpdateQuantity(dto);  
            return Ok();    
        }
        [HttpDelete]
        public IActionResult RemoveFromCart()
        {
            /// 
            return Ok();
        }
    }
}
