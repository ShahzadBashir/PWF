#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PWF.DataLayer.Models;

namespace PWF.Web.Api.Data
{
    public class PWFWebApiContext : DbContext
    {
        public PWFWebApiContext (DbContextOptions<PWFWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }

    }
}
