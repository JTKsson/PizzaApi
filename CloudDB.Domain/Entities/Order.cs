using System.ComponentModel.DataAnnotations;

namespace CloudDB.Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int TotalPrice { get; set; }
        public List<Product> Products { get; set; }
        public User User { get; set; }
    }
}

//orderID
//meals(list)
//totalPrice
//userID(FK)
//status(statusId FK ???)