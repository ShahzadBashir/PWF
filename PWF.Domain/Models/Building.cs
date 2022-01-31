using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWF.Domain.Models
{
    // Suggested to be deleted according to replacements by issue 13
    public class Building
    {
        public int Id { get; set; }
        public string? Address1 { get; set; }
        public string? EntryCode { get; set; }
        public string? Notes { get; set; }
    }
}
