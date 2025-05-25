using CloudDB.Core.Interfaces;
using CloudDB.Domain.DTO;
using CloudDB.Infrastructure.Interfaces;

namespace CloudDB.Core.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepo _repo;

        public IngredientService(IIngredientRepo repo)
        {
            _repo = repo;
        }

        public async Task AddIngredient(IngredientDTO.IngredientAddDTO ingredient)
        {
            await _repo.AddIngredient(ingredient);
        }

        public async Task UpdateIngredient(IngredientDTO.IngredientUpdateDTO ingredient)
        {
            await _repo.UpdateIngredient(ingredient);
        }
    }
}
