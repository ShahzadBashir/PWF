using PWF.Services.Models;
using SendGrid.Helpers.Mail;
using SendGrid;
using PWF.Services.Settings;
using Microsoft.Extensions.Options;

namespace PWF.Services.Email;

public class SendGridEmailService : IEmailService
{
    private readonly SendGridEmailSettings _sendGridEmailSettings;

    public SendGridEmailService(IOptions<SendGridEmailSettings> sendGridEmailSettings)
    {
        _sendGridEmailSettings = sendGridEmailSettings.Value;
    }

    public async Task SendEmail(EmailRequest emailRequest)
    {
        try
        {
            var apiKey = _sendGridEmailSettings.ApiKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(_sendGridEmailSettings.Mail, _sendGridEmailSettings.SenderName);
            var to = new EmailAddress(emailRequest.ToEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, emailRequest.Subject, emailRequest.Body, emailRequest.Body);
            var response = await client.SendEmailAsync(msg);
            if (!response.IsSuccessStatusCode)
                throw new SendGridException("Exception happen when sending email");

        }
        catch (Exception)
        {
            return;
        }
    }
}
public class SendGridException : Exception
{
    public SendGridException(string message) : base(message) { }
}