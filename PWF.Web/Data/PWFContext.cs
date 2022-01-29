using Microsoft.EntityFrameworkCore;
using PWF.DataLayer.Models;

namespace PWF.Web.Data
{
    public class PWFContext:DbContext
    {
        public PWFContext(DbContextOptions<PWFContext> options)
            : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
