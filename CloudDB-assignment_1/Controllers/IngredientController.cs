using CloudDB.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CloudDB.Domain.DTO.IngredientDTO;

namespace CloudDB_assignment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class IngredientController : ControllerBase
    {
        public readonly IIngredientService _service;

        public IngredientController(IIngredientService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredient(IngredientAddDTO ingredient)
        {
            if (ingredient == null)
                return BadRequest("Ingredient data is required.");

            try
            {
                await _service.AddIngredient(ingredient);
                return Ok("Ingredient added successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateIngredient(IngredientUpdateDTO ingredient)
        {
            if (ingredient == null)
                return BadRequest("Ingredient data is required.");

            try
            {
                await _service.UpdateIngredient(ingredient);
                return Ok("Ingredient updated successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
