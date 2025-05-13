using Microsoft.EntityFrameworkCore;

namespace CloudDB.Infrastructure
{
    public class CloudDBContext : DbContext
    {
        public CloudDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
