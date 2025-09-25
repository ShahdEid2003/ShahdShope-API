using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShahdShope.BLL.Services.interfaces;
using ShahdShope.DAL.DTO.Requests;
using System.Security.Claims;

namespace ShahdShope.PL.Areas.Customer.Controllers
{

    [Route("api/[Area]/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class CheckoutController:ControllerBase
    {
        private readonly ICheckOutService _checkoutService;


        public CheckoutController(ICheckOutService checkoutService)
        {
            _checkoutService = checkoutService;
        }
        [HttpPost("payment")]
        public async Task<IActionResult> Payment([FromBody] CheckoutRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var response = await _checkoutService.ProccessPaymentAsync(request, userId, Request);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("success/{orderId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Success([FromRoute] int orderId)
        {
            var result = await _checkoutService.HendelPaymentSuccessAsync(orderId);
            return Ok(result);
        }
    }
}
