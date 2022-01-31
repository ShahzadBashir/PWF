using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PWF.Domain.Models
{
    public class InvoiceDetail
    {
        [Key, ForeignKey("Invoice")]
        [Column(Order = 1)]
        public int InvoiceId { get; set; }
        [Key, ForeignKey("Product")]
        [Column(Order = 2)]
        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public double SoldPrice { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
    }
}
