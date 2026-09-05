using Isteyap.Core.Application.Configurations.AppSettings;
using Isteyap.Core.Application.Services;
using Isteyap.Core.Application.Services.Interfaces;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MailKit.Security;
using MailKit.Net.Smtp;

namespace Isteyap.Infrastructure.Infrastructure.Services
{
    public sealed class EmailService(
    IOptions<EmailOptions> options) : IEmailService
    {
        private readonly EmailOptions _options = options.Value;

        public async Task SendAsync(
            EmailMessage message,
            CancellationToken cancellationToken = default)
        {
            var email = new MimeMessage();

            email.From.Add(
                new MailboxAddress(
                    _options.FromName,
                    _options.FromAddress));

            email.To.Add(
                MailboxAddress.Parse(message.To));

            email.Subject = message.Subject;

            var bodyBuilder = new BodyBuilder();

            if (message.IsHtml)
            {
                bodyBuilder.HtmlBody = message.Body;
            }
            else
            {
                bodyBuilder.TextBody = message.Body;
            }

            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();

            await smtp.ConnectAsync(
                _options.Host,
                _options.Port,
                _options.UseSsl
                    ? SecureSocketOptions.StartTls
                    : SecureSocketOptions.SslOnConnect,
                cancellationToken);

            await smtp.AuthenticateAsync(
                _options.Username,
                _options.Password,
                cancellationToken);

            await smtp.SendAsync(
                email,
                cancellationToken);

            await smtp.DisconnectAsync(
                true,
                cancellationToken);
        }
    }
}
