using static CloudDB.Domain.DTO.IngredientDTO;

namespace CloudDB.Core.Interfaces
{
    public interface IIngredientService
    {
        Task AddIngredient(IngredientAddDTO ingredient);
        Task UpdateIngredient(IngredientUpdateDTO ingredient);
    }
}
