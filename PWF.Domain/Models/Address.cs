using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWF.Domain.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
        [Required]
        public string AddressFirstLine { get; set; }
        public string AddressSecondLine { get; set; }
        [Required]
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool? IsShipTo { get; set; }
        public bool? IsBillTo { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public bool Enabled { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual List<Delivery> Deliveries { get; set; }
    }
}
