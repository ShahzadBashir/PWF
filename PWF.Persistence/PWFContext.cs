using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PWF.Domain.Models;

namespace PWF.Persistence
{
    public class PWFContext : IdentityDbContext<ApplicationUser>, IPWFContext
    {
        public PWFContext()
        {
        }

        public PWFContext(DbContextOptions<PWFContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).SeedRoles();
        }
        public class DbInitializer
        {
            private readonly ModelBuilder modelBuilder;
            private readonly UserManager<ApplicationUser> userManager;

            public DbInitializer(ModelBuilder modelBuilder)
            {
                this.modelBuilder = modelBuilder;
            }
            
            public void SeedRoles()
            {
                modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Customer", ConcurrencyStamp = "1", NormalizedName = "Customer" },
                new IdentityRole() { Id = "c7b013f2-5202-4327-bbd2-c211f91b7332", Name = "Admin", ConcurrencyStamp = "2", NormalizedName = "Admin" },
                new IdentityRole() { Id = "c7b013f3-5203-4337-cbd3-c211f91b7333", Name = "Driver", ConcurrencyStamp = "3", NormalizedName = "Driver" },
                new IdentityRole() { Id = "c7b013f4-5204-4347-dbd4-c211f91b7334", Name = "Sales", ConcurrencyStamp = "4", NormalizedName = "Sales" },
                new IdentityRole() { Id = "c7b013f5-5205-4357-ebd5-c211f91b7335", Name = "SalesManager", ConcurrencyStamp = "5", NormalizedName = "Sales Manager" }
                );
            }
        }
    }
}
