using PWF.Services.Models;

namespace PWF.Services.Email
{
    public interface IEmailService
    {
        /// <summary>
        /// Sends email with attacments to an email address.
        /// </summary>
        /// <param name="emailRequest">mail Request object holding to email address, subject, body and attachments.</param>
        Task SendEmail(EmailRequest emailRequest);
    }
}
