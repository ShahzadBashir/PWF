using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWF.Domain.Models
{
    public class Customer : ApplicationUser
    {
        public DateTime? BirthDate { get; set; }

        public virtual List<Address> Addresses { get; set; }
        public virtual List<ShoppingCart> ShoppingCarts { get; set; }
        public virtual List<Invoice> Invoices { get; set; }
    }
}
