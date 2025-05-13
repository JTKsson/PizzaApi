using System.ComponentModel.DataAnnotations;

namespace CloudDB.Domain.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(50), Required]
        public string Username { get; set; }

        [StringLength(50), Required]
        public string Password { get; set; }

        [StringLength(50), Required]
        public string Email { get; set; }
        [StringLength(20)]

        public string Phone { get; set; }
        //public List<Order> { get; set; }
    }
}
