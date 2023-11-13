using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace Manero.Services;

public class EmailService
{
   public async Task SendPasswordResetEmailAsync(string userEmail, string passwordResetLink)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Manero", "manero-brand@outlook.com"));
        message.To.Add(new MailboxAddress("", "manero-brand@outlook.com"));
        message.Subject = "Password Reset Link";

        var textPart = new TextPart("plain")
        {
            Text = $"Click the following link within 24 hours to reset your password: {passwordResetLink}"
        };

        message.Body = textPart;

        using var client = new SmtpClient();
        await client.ConnectAsync("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync("manero-brand@outlook.com", "BytMig123!");
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}
