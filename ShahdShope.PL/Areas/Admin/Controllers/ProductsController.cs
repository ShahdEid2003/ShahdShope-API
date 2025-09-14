using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShahdShope.BLL.Services.interfaces;
using ShahdShope.DAL.DTO.Requests;

namespace ShahdShope.PL.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ProductsController:ControllerBase
    {
        private readonly IProducttService _productServices;

        public ProductsController(IProducttService productServices)
        {
            _productServices = productServices;
        }

        [HttpGet("")]
        public async Task<ActionResult> GetAll() => Ok(_productServices.GetAll());

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] ProductRequest productRequest)
        {
            // var userId=User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _productServices.CreateFile(productRequest);
            return Ok(result);
        }
    }
}
