using System.ComponentModel.DataAnnotations;

namespace CloudDB.Domain.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [StringLength(70)]
        public string ProductName { get; set; }

        public int ProductPrice { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public Category Category { get; set; }
    }
}


//mealId
//mealName
//price
//description
//ingredients(list)
//mealCategory