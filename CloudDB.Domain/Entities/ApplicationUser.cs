using Microsoft.AspNetCore.Identity;

namespace CloudDB.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public List<Order> Orders { get; set; }
        public int BenefitPoints { get; set; }
    }
}
