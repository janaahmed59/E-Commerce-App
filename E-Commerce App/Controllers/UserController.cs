using E_Commerce_App.DTOs.UserDTO;
using E_Commerce_App.Models;
using E_Commerce_App.Services.Interface;
using E_Commerce_App.UnitOfWorkLayer;
using E_Commerce_App.UnitOfWorkLayer.Interface;
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
        public IActionResult UpdatePassword( UpdatePassDTO dto)
        {
            var userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            userService.UpdateProfile(userid, dto);
            return Ok();
        }
        [HttpPut("updateusername")]
        public IActionResult UpdateUsername(UpdateUsernameDTO dto)
        {
            var userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            userService.Updateusername(userid, dto);
            return Ok();
        }
        [HttpDelete("deleteuser")]
        public IActionResult DeleteUser()
        {
            var userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            userService.DeleteProfile(userid);
            return Ok();
        }
    }
}
