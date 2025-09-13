using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShahdShope.BLL.Services.interfaces;
using ShahdShope.DAL.DTO.Requests;
using ShahdShope.DAL.DTO.Responses;

namespace ShahdShope.PL.Areas.Identity.Controllers
{
    [Route("api/[Area]/[controller]")]
    [ApiController]
    [Area("Identity")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("Register")]

        public async Task<ActionResult<UserResponse>> Register(RegisterRequest request)
        {
            var result = await _authenticationService.RegisterAsync(request);
            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserResponse>> Login(LoginRequest request)
        {
            var result = await _authenticationService.LoginAsync(request);
            return Ok(result);
        }
        [HttpGet("ConfirmEmail")]
        public async Task<ActionResult<string>> ConfirmEmail([FromQuery] string token, [FromQuery] string userId)
        {
            var result = await _authenticationService.ConfirmEmail(token, userId);
            return Ok(result);
        }
        [HttpPost("ForgetPassword")]
        public async Task<ActionResult<string>> ForgetPassword([FromBody] ForgetPasswordRequest request)
        {
            var result = await _authenticationService.ForgetPassword(request);
            return Ok(result);
        }
        [HttpPatch("ResetPassword")]
        public async Task<ActionResult<string>> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var result = await _authenticationService.ResetPassword(request);
            return Ok(result);
        }

    }
}
