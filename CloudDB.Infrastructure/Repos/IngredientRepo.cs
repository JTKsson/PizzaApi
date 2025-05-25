using CloudDB.Domain.DTO;
using CloudDB.Domain.Entities;
using CloudDB.Infrastructure.Identity;
using CloudDB.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CloudDB.Infrastructure.Repos
{
    public class IngredientRepo : IIngredientRepo
    {

        private readonly ApplicationUserContext _context;

        public IngredientRepo(ApplicationUserContext context)
        {
            _context = context;
        }

        public async Task AddIngredient(IngredientDTO.IngredientAddDTO ingredient)
        {
            var ingredientDto = new Ingredient
            {
                IngredientName = ingredient.IngredientName
            };

            await _context.Ingredients.AddAsync(ingredientDto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIngredient(IngredientDTO.IngredientUpdateDTO ingredient)
        {
            var existingIngredient = await _context.Ingredients
                .SingleOrDefaultAsync(i => i.IngredientId == ingredient.IngredientId);

            if (existingIngredient == null)
                throw new ArgumentException($"No ingredient found with ID {ingredient.IngredientId}");

            existingIngredient.IngredientName = ingredient.IngredientName;

            await _context.SaveChangesAsync();
        }

    }
}
