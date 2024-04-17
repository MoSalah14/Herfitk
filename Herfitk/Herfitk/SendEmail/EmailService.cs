using Microsoft.Extensions.Options;
using Herfitk.API.SendEmail;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

public class EmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;

    public EmailService(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public void SendEmail(EmailData email)
    {
        var mail = new MimeMessage
        {
            Sender = MailboxAddress.Parse(_emailSettings.Email),
            Subject = email.Subject
        };

        mail.To.Add(MailboxAddress.Parse(email.To));
        var builder = new BodyBuilder();
        builder.TextBody = email.Body;
        mail.Body = builder.ToMessageBody();
        mail.From.Add(new MailboxAddress(_emailSettings.DisplayName, _emailSettings.Email));

        using var smtp = new SmtpClient();
        smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(_emailSettings.Email, _emailSettings.Password);
        smtp.Send(mail);
        smtp.Disconnect(true);
    }
}