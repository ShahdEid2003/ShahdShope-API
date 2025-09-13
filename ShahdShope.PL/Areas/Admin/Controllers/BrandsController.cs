using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShahdShope.BLL.Services.interfaces;
using ShahdShope.DAL.DTO.Requests;


namespace ShahdShope.PL.Areas.Admin.Controllers
{
    [Route("api/[Area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]

    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService _brandService)
        {
            this._brandService = _brandService;
        }

        [HttpGet("")]

        public IActionResult GetAll()
        {
            return Ok(_brandService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var brand = _brandService.GetById(id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }
        [HttpPost]

        public IActionResult Create([FromBody] BrandRequest request)
        {
            var id = _brandService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id }, new { message = "ok" });
        }
        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] BrandRequest request)
        {
            var update = _brandService.Update(id, request);
            return update > 0 ? Ok() : NotFound();
        }
        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id)
        {
            var updated = _brandService.ToggleStatus(id);
            return updated ? Ok(new { message = "status toggled" }) : NotFound(new { message = "brand not found" });
        }
        [HttpDelete("Id")]
        public IActionResult Delete(int id)
        {
            var deleted = _brandService.Delete(id);
            return deleted > 0 ? Ok() : NotFound();
        }
    }
}
