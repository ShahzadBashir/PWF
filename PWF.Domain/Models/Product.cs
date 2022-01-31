using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PWF.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string SKU { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public float ListPrice { get; set; }
        public float SellPrice { get; set; }

        public virtual List<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual List<ShoppingCartDetail> ShoppingCartDetails { get; set; }
    }
}
