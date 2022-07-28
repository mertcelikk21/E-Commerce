using eTicaret.Core.DbModels;
using eTicaret.Core.DbModels.Identity;
using eTicaret.Core.DbModels.OrderAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Address = eTicaret.Core.DbModels.Identity.Address;

namespace eTicaret.Infrastructure.DataContext
{
    public class StoreContext:IdentityDbContext<AppUser>
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            :base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }

    }
}
