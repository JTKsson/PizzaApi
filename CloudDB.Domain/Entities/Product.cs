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
        public Category Category { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}