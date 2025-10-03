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
        public IActionResult GetAll([FromQuery] int pageNumbe = 1, [FromQuery] int pageSize = 5)
        {
            var products = _productServices.GetAllProduct(Request, false, pageNumbe, pageSize);
            return Ok(products);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] ProductRequest productRequest)
        {
            var result = await _productServices.CreateProduct(productRequest);
            return Ok(result);
        }
    }
}
