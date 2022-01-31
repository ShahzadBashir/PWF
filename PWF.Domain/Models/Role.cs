using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PWF.Domain.Models
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public bool Enabled { get; set; }

        public Role()
        {

        }

        public Role(string roleName)
        {
            this.Name = roleName;
        }
    }
}
