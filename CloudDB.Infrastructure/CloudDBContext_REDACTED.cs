using CloudDB.Domain.Entities;
using CloudDB.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace CloudDB.Infrastructure
{
    public class CloudDBContext_REDACTED : DbContext
    {
        public CloudDBContext_REDACTED(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>()
               .HasMany(i => i.Products)
               .WithMany(p => p.Ingredients);

            modelBuilder.Entity<Product>()
               .HasMany(p => p.Orders)
               .WithMany(o => o.Products);
        }
    }
}
