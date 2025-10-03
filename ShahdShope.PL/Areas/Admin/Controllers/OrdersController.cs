using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShahdShope.BLL.Services.interfaces;
using ShahdShope.DAL.Models;

namespace ShahdShope.PL.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    //[Authorize(Roles = "Admin,SuperAdmin")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPatch("ChangeStatus/{orderId}")]
        public async Task<IActionResult> ChangeStatus(string orderId, StatusOrderEnum newStatus)
        {
            var isChanged = await _orderService.ChangeStatusAsync(orderId, newStatus);
            if (!isChanged)
                return BadRequest("Status not changed");
            return Ok("Status changed successfully");
        }

        [HttpGet("Status/{status}")]
        public async Task<IActionResult> GetByStatus(StatusOrderEnum status)
        {
            var order = await _orderService.GetByStatus(status);
            return Ok(order);
        }
        
    }
}
