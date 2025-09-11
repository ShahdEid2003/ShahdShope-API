using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShahdShope.BLL.Services.interfaces;


namespace ShahdShope.PL.Areas.Customer.Controllers
{
    [Route("api/[Area]/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryServiece;

        public CategoryController(ICategoryService categoryServiece)
        {
            _categoryServiece = categoryServiece;
        }

        [HttpGet("")]
        public IActionResult GetAll() => Ok(_categoryServiece.GetAll());


        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var categoty = _categoryServiece.GetById(id);
            if (categoty == null)
            {
                return NotFound();
            }
            return Ok(categoty);
        }
    }
}
