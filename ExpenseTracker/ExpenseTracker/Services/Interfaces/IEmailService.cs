namespace ExpenseTracker.Services.Interfaces;

public interface IEmailService
{
    Task SendEmailAsync(string email, string subject, string message, byte[]? attachment, string? attachmentName);
}
