using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using PWF.Services.Models;
using PWF.Services.Settings;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace PWF.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }


        /// <inheritdoc/>
        public async Task SendEmail(EmailRequest emailRequest)
        {
            try
            {
                MimeMessage email = new MimeMessage()
                {
                    Sender = MailboxAddress.Parse(_emailSettings.Mail),
                    Subject = emailRequest.Subject
                };

                email.To.Add(MailboxAddress.Parse(emailRequest.ToEmail));

                BodyBuilder builder = new BodyBuilder()
                {
                    HtmlBody = emailRequest.Body
                };
                email.Body = builder.ToMessageBody();

                using SmtpClient smtp = new SmtpClient();
                smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailSettings.Mail, _emailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch (Exception e)
            {
                return;
            }
        }
    }
}
