using E_Commerce_App.DTOs.ProductDTO;
using E_Commerce_App.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _product;
        public ProductController(IProductService product)
        {
            _product = product;
        }
        [HttpGet("GetbyId")]
        public IActionResult GetProductByID(int id)
        {
            var list = _product.GetById(id);
            return Ok(list);
        }
        [HttpGet("Search")]
        public IActionResult SearchForProduct(string name)
        {
            var product = _product.SearchForProduct(name);
            return Ok(product);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddProduct(CreateProductDTO dto)
        {
            _product.CreateProduct(dto);
            return Ok();
        }
        [HttpPut("Price")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdatePrice(int id, UpdatePriceDTO dto)
        {
            _product.UpdatePrice(id, dto);
            return Ok();
        }
        [HttpPut("Description")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateDescription(int id, UpdateDescriptionDTO dto)
        {
            _product.UpdateDescription(id, dto);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _product.DeleteProduct(id);
            return Ok();
        }
    }
}
