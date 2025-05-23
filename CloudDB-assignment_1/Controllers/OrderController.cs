using CloudDB.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static CloudDB.Domain.DTO.OrderDTO;

namespace CloudDB_assignment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddOrder(OrderCreateDTO orderDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (orderDto == null) return BadRequest("Please enter order");
            if (userId == null) return Unauthorized("No authentication found");

            await _service.AddOrder(orderDto, userId);
            return Created();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAuthUserOrders()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized("No authentication found");

            var orders = await _service.GetAuthUserOrders(userId);
            return Ok(orders);
        }
    }
}
