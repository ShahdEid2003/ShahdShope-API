using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShahdShope.BLL.Services.classes;

namespace ShahdShope.PL.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize( Roles = "Admin,SuperAdmin")]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;

        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }
        [HttpGet("ProductPdf")]
        public IActionResult GenerateProductReport()
        {
            _reportService.GenerateProductReport();
            return Ok("PDF report generated successfully.");
        }
    }
}
