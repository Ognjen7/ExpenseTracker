using ExpenseTracker.Services.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace ExpenseTracker.Services;

public class EmailService : IEmailService
{
    IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string email, string subject, string message, byte[]? attachment, string? attachmentName)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("Expense Tracker", _configuration["Email:From"]));
        emailMessage.To.Add(new MailboxAddress("", email));
        emailMessage.Subject = subject;

        var bodyBuilder = new BodyBuilder { HtmlBody = message };

        if (attachment != null && attachment.Length > 0)
        {
            bodyBuilder.Attachments.Add(attachmentName, attachment);
        }

        emailMessage.Body = bodyBuilder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;

            await client.ConnectAsync(_configuration["Email:SmtpServer"], int.Parse(_configuration["Email:Port"]), bool.Parse(_configuration["Email:UseSsl"]));
            await client.AuthenticateAsync(_configuration["Email:Username"], _configuration["Email:Password"]);

            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}
