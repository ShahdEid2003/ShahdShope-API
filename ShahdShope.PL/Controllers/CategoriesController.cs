using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShahdShope.BLL.Services;
using ShahdShope.DAL.Data;
using ShahdShope.DAL.DTO.Requests;

namespace ShahdShope.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(categoryService.GetAllCategories());
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var category = categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost]

        public IActionResult Create([FromBody] CategoryRequest request)
        {
            var id = categoryService.CreateCategory(request);
            return CreatedAtAction(nameof(GetById), new { id });
        }
        [HttpPatch("{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] CategoryRequest request)
        {
            var update = categoryService.UpdateCategory(Id, request);
            return update > 0 ? Ok() : NotFound();
        }
        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id)
        {
            var updated = categoryService.ToggleStatus(id);
            return updated ? Ok(new { message = "status toggled" }) : NotFound(new { message = "category not found" });
        }
        [HttpDelete("Id")]
        public IActionResult Delete(int id)
        {
            var deleted = categoryService.DeleteCategory(id);
            return deleted > 0 ? Ok() : NotFound();
        }

    }
}
