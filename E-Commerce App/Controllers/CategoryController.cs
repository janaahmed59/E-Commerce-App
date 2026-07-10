using E_Commerce_App.DTOs.CategoryDTO;
using E_Commerce_App.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _category;
        public CategoryController(ICategoryService category)
        {
            _category = category;
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _category.GetAllCategories();
            return Ok(categories);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateCategory(CreateCategoryDTO dto)
        {
            _category.CreateCategory(dto);
            return Ok("Creted succesfully");
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateCategory(int id, UpdateCategoryDTO dto)
        {
            _category.UpdateCategory(id, dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategory(int id)
        {
            _category.DeleteCategory(id);
            return Ok();
        }
    }
}
