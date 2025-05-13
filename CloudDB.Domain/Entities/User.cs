using System.ComponentModel.DataAnnotations;

namespace CloudDB.Domain.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(50), Required]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(20)]

        public string Phone { get; set; }
        public List<Order> Orders { get; set; }
    }
}
