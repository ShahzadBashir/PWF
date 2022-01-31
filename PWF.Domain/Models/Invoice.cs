using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWF.Domain.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }


        public virtual Customer Customer { get; set; }
        public virtual List<InvoiceDetail> Details { get; set; }
        public virtual List<Delivery> Deliveries { get; set; } // An employee may attempt to deliver a shipment, but he cannot reach the customer, so the next day the shipment can be carried out and possibly with another employee. 
    }
}
