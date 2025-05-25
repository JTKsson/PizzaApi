using System.ComponentModel.DataAnnotations;

namespace CloudDB.Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int TotalPrice { get; set; }
        public bool IsDelivered { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}