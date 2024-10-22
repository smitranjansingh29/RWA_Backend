using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using RWA.Models;
using System.IO;
using System.Threading.Tasks;

namespace RWA.Services
{
    public class SmtpService
    {
        private readonly SmtpSettings _smtpSettings;

        public SmtpService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendEmailAsync(string recipientEmail, string subject, string message)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_smtpSettings.Username));
            email.To.Add(MailboxAddress.Parse(recipientEmail));
            email.Subject = subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpSettings.Host, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

        public async Task SendEmailWithAttachmentAsync(string recipientEmail, string subject, string message, string attachmentFilePath)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_smtpSettings.Username));
            email.To.Add(MailboxAddress.Parse(recipientEmail));
            email.Subject = subject;

            var builder = new BodyBuilder { TextBody = message };

            // Add attachment
            if (File.Exists(attachmentFilePath))
            {
                builder.Attachments.Add(attachmentFilePath);
            }

            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpSettings.Host, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

        public async Task SendEmailWithAttachmentsAsync(string recipientEmail, string subject, string message, List<string> attachmentFilePaths)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_smtpSettings.Username));
            email.To.Add(MailboxAddress.Parse(recipientEmail));
            email.Subject = subject;

            var builder = new BodyBuilder { TextBody = message };

            // Add multiple attachments
            foreach (var attachmentFilePath in attachmentFilePaths)
            {
                if (File.Exists(attachmentFilePath))
                {
                    builder.Attachments.Add(attachmentFilePath);
                }
            }

            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpSettings.Host, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

    }
}



/*
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;
using RWA.Models;
using Microsoft.Extensions.Options;

namespace RWA.Services
{
    public class SmtpService
    {
        private readonly SmtpSettings _smtpSettings;

        public SmtpService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendEmailAsync(string recipientEmail, string subject, string message)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_smtpSettings.Username));
            email.To.Add(MailboxAddress.Parse(recipientEmail));
            email.Subject = subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpSettings.Host, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
*/