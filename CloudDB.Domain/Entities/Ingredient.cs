using System.ComponentModel.DataAnnotations;

namespace CloudDB.Domain.Entities
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        [StringLength(50), Required]
        public string IngredientName { get; set; }
    }
}
