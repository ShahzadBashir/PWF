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
        [Key]
        public int Id { get; set; }
        
        public int InvoiceId { get; set; }
        
        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public double SoldPrice { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
    }
}
