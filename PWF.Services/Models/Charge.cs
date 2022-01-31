using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWF.Services.Models
{
    public class ChargeObj 
    {
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string ReceiptEmail { get; set; }
        public string CustomerId { get; set; }
        public string Description { get; set; }
    }
}
