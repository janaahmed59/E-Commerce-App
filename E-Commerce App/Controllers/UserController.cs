using E_Commerce_App.DTOs.UserDTO;
using E_Commerce_App.Services.Interface;
using E_Commerce_App.UnitOfWorkLayer;
using E_Commerce_App.UnitOfWorkLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace E_Commerce_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService service)
        {
            userService = service;
        }
        [HttpGet("getall")]
        [Authorize (Roles = "Admin")]
        public IActionResult GetAllUsers()
        {
            return Ok(userService.GetAllUsers()); 
        }
        [HttpPut("updatepassword")]
        public IActionResult UpdatePassword(int id , UpdatePassDTO dto)
        {
            userService.UpdateProfile(id, dto);
            return Ok();
        }
        [HttpPut("updateusername")]
        public IActionResult UpdateUsername(int id, UpdateUsernameDTO dto)
        {
            userService.Updateusername(id, dto);
            return Ok();
        }
        [HttpDelete("deleteuser")]
        public IActionResult DeleteUser(int id)
        {
            userService.DeleteProfile(id);
            return Ok();
        }
    }
}
