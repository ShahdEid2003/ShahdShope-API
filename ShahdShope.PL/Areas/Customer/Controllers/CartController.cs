using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShahdShope.BLL.Services.interfaces;
using ShahdShope.DAL.DTO.Requests;
using System.Security.Claims;

namespace ShahdShope.PL.Areas.Customer.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize( Roles = "Customer")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddCart(CartRequest request)
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _cartService.AddToCartAsync(request, UserId);
            if (!result)
            {
                return NotFound("Failed to add to cart.");
            }
            return Ok();
        }
        [HttpGet("summary")]
        public async Task<IActionResult> GetUserCart()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _cartService.CartSummaryResponseAsync(UserId);
            return Ok(result);
        }
    }
}
