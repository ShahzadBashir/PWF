using Microsoft.EntityFrameworkCore;
using PWF.Domain.Models;

namespace PWF.Persistence
{
    public interface IPWFContext
    {
        
        DbSet<Customer> Customers { get; set; }
        DbSet<Building> Buildings { get; set; }
        DbSet<Product> Products { get; set; }

    }
}
