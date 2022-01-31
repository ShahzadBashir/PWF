using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PWF.Domain.Models
{
    public enum EmailSendStatus
    {
        Pending,
        Promised,
        Sent,
        Failed
    }

    public class Email
    {
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public string CreatedBy { get; set; }
        public bool IsHTML { get; set; }

        public EmailSendStatus Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
