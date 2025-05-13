using System.ComponentModel.DataAnnotations;

namespace CloudDB.Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int TotalPrice { get; set; }
        //public List<Product> Products { get; set; }
        public User User { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}

//orderID
//meals(list)
//totalPrice
//userID(FK)
//status(statusId FK ???)