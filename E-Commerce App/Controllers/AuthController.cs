using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Commerce_App.UnitOfWorkLayer;
using E_Commerce_App.UnitOfWorkLayer.Interface;
using E_Commerce_App.Services.Interface;
using E_Commerce_App.Services.ServiceImplementation;
using E_Commerce_App.DTOs.UserDTO;
namespace E_Commerce_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _service;
        public AuthController(IAuthenticationService service) => _service = service;

        [HttpPost("register")]
        public IActionResult Register(RegisterUserDTO dto)
        {
            return Ok(_service.Register(dto));
        }
        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var user = _service.Login(dto);
            if (user == null) return NotFound();
            else return Ok(user);
            // return Ok(_service.Login(dto));
        }
    }
}
