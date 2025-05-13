using System.ComponentModel.DataAnnotations;

namespace CloudDB.Domain.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(50), Required]
        public string CategoryName { get; set; }
    }
}
