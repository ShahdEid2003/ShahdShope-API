using ShahdShope.BLL.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShahdShope.PL.Areas.Customer.Controllers
{
    [Route("api/[Area]/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandServices;

        public BrandsController(IBrandService brandServices)
        {
            _brandServices = brandServices;
        }
        [HttpGet("")]
        public IActionResult GetAll() => Ok(_brandServices.GetAll(true));


        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var brand = _brandServices.GetById(id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }
    }
}
