
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;

//namespace ShahdShope.PL.Areas.Admin.Controllers
//{
//    [Route("api/[area]/[controller]")]
//    [ApiController]
//    [Area("Admin")]
//    //[Authorize(Roles = "Admin,SuperAdmin")]
    
//    public class ProductController : ControllerBase
//    {
//        private readonly IProductService _productServices;

//        public ProductController(IProductServices productServices)
//        {
//            _productServices = productServices;
//        }

//        [HttpGet("")]
//        public async Task<ActionResult> GetAll()=> Ok(_productServices.GetAll());
       
//        [HttpPost("Create")]
//        public async Task<IActionResult> Create([FromForm]ProductRequest productRequest)
//        {
//           // var userId=User.FindFirstValue(ClaimTypes.NameIdentifier);
//            var result =await _productServices.CreateFile(productRequest);
//            return Ok(result);
//        }
//    }
//}
