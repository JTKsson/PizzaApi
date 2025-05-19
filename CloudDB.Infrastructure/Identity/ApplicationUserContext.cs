using CloudDB.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CloudDB.Infrastructure.Identity
{
    public class ApplicationUserContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationUserContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ApplicationUser> Users {  get; set; }
        //public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ingredient>()
               .HasMany(i => i.Products)
               .WithMany(p => p.Ingredients);

            modelBuilder.Entity<Product>()
               .HasMany(p => p.Orders)
               .WithMany(o => o.Products);

            //modelBuilder.Entity<ApplicationUser>()
            //   .HasMany(u => u.Orders)
            //   .WithOne(o => o.User)
            //   .HasForeignKey(o => o.UserId);
        }
    }
}
