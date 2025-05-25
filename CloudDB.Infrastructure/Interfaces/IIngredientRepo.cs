using static CloudDB.Domain.DTO.IngredientDTO;

namespace CloudDB.Infrastructure.Interfaces
{
    public interface IIngredientRepo
    {
        Task AddIngredient(IngredientAddDTO ingredient);
        Task UpdateIngredient(IngredientUpdateDTO ingredient);
    }
}
