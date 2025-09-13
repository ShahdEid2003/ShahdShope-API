
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShahdShope.BLL.Services.interfaces;
using ShahdShope.DAL.DTO.Requests;

namespace ShahdShope.PL.Areas.Admin.Controllers
{
    [Route("api/[Area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
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
        [HttpPost]

        public IActionResult Create([FromBody] CategoryRequest request)
        {
            var id = _categoryServiece.Create(request);
            return CreatedAtAction(nameof(GetById), new { id }, new { message = "Ok " });
        }
        [HttpPatch("{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] CategoryRequest request)
        {
            var update = _categoryServiece.Update(Id, request);
            return update > 0 ? Ok() : NotFound();
        }
        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id)
        {
            var update = _categoryServiece.ToggleStatus(id);
            return update ? Ok(new { message = "status toggled" }) : NotFound(new { message = "brand not found" });
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _categoryServiece.Delete(id);
            return deleted > 0 ? Ok() : NotFound();
        }
    }
}
