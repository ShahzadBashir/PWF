using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWF.Domain.Models
{
    public class ShoppingCartDetail
    {
        [Key]
        public int Id { get; set; }
        public int ShoppingCartId { get; set; }
       
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual Product Product { get; set; }
    }
}
