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
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpPost()]
        public async Task<IActionResult> AddReviews([FromBody] ReviewRequest reviewRequest)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _reviewService.AddReviewAsync(reviewRequest, userId);
            return Ok(result);
        }
    }
}
