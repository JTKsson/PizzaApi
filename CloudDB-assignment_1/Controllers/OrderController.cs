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
        [Route("api/add-order")]
        public async Task<IActionResult> AddOrder(OrderCreateDTO orderDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (orderDto == null) return BadRequest("Please enter order");
            if (userId == null) return Unauthorized("No authentication found");

            if (User.IsInRole("PremiumUser"))
            {
                await _service.AddPremiumOrder(orderDto, userId);
                return Created();
            }
            else
            {
                await _service.AddOrder(orderDto, userId);
                return Created();
            }            
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

        [HttpDelete("{orderId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveOrder(int orderId)
        {
            try
            {
                await _service.RemoveOrder(orderId);
                return Ok("Order removed successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{orderId}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeOrderStatus(int orderId, [FromQuery] bool isDelivered)
        {
            try
            {
                await _service.ChangeOrderStatus(orderId, isDelivered);
                return Ok("Order status updated successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
