using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShahdShope.BLL.Services.interfaces;
using ShahdShope.DAL.DTO.Requests;

namespace ShahdShope.PL.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPatch("BlockUser/{userId}")]

        public async Task<IActionResult> BlockUser([FromRoute] string userId, [FromBody] int days)
        {
            var result = await _userService.BlockUserAsync(userId, days);
            if (!result)
            {
                return BadRequest("Unable to block user.");
            }
            return Ok("User blocked successfully.");
        }

        [HttpPatch("UnBlockUser/{userId}")]

        public async Task<IActionResult> UnBlockUser([FromRoute] string userId)
        {
            var result = await _userService.UnBlockUserAsync(userId);
            if (!result)
            {
                return BadRequest("Unable to block user.");
            }
            return Ok("User blocked successfully.");
        }
        [HttpGet("IsBlockUser/{userId}")]
        public async Task<IActionResult> IsBlockUser([FromRoute] string userId)
        {
            var result = await _userService.UnBlockUserAsync(userId);
            if (!result)
            {
                return BadRequest("Unable to block user.");
            }
            return Ok("User blocked successfully.");
        }
        [HttpPatch("ChangeUserRole/{userId}")]
        public async Task<IActionResult> ChangeUserRole([FromRoute] string userId, [FromBody] ChangRoleRequest request)
        {
            var result = await _userService.ChangeUserRoleAsync(userId, request.RoleName);
            if (!result)
            {
                return BadRequest("Unable to change user role.");
            }
            return Ok("User role changed successfully.");
        }
    }
}
