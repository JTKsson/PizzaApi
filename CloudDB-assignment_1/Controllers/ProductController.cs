using CloudDB.Core.Interfaces;
using CloudDB.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloudDB_assignment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreateDTO product)
        {
            if (product == null)
                return BadRequest("Product data is required.");

            try
            {
                await _service.CreateProduct(product);
                return Ok("Product created successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDTO product)
        {
            if (product == null)
                return BadRequest("Product data is required.");

            try
            {
                await _service.UpdateProduct(product);
                return Ok("Product updated successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
