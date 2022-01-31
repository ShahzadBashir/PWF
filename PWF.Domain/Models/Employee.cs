using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWF.Domain.Models
{
    public class Employee : ApplicationUser
    {
        public virtual List<Delivery> Deliveries { get; set; }
    }
}
