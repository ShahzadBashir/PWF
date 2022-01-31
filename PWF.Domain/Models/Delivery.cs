using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWF.Domain.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int InvoiceId { get; set; }
        public int AddressId { get; set; }

        public DateTimeOffset DateTimeDelivered { get; set; }
        public DateTimeOffset EstimatedDeliveryTime { get; set; }
        public DateTimeOffset DueDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Address Address { get; set; }
    }
}
