using Microsoft.EntityFrameworkCore;
using PWF.Domain.Models;

namespace PWF.Persistence
{
    public class PWFContext : DbContext, IPWFContext
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

    }
}
