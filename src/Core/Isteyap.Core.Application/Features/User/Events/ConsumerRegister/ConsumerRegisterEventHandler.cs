using Isteyap.Core.Application.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Features.User
{
    public class ConsumerRegisterEventHandler : INotificationHandler<ConsumerRegisterEvent>
    {
        private readonly IEmailService _emailService;

        public ConsumerRegisterEventHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(ConsumerRegisterEvent notification, CancellationToken cancellationToken)
        {

            var request = new Services.EmailMessage()
            {
                Body = GenerateVerificationEmail(notification.FullName,notification.VerificationLink),
                IsHtml = true,
                Subject = "İsteyap Hesap Doğrulama",
                To = notification.Email
            };
            await _emailService.SendAsync(request, cancellationToken);
        }

        public string GenerateVerificationEmail(string userName, string verificationLink)
        {
            // C# 11+ Raw String Literal kullanımı (""" ... """)
            string htmlBody = $"""
                <!DOCTYPE html>
                <html lang="tr">
                <head>
                    <meta charset="UTF-8">
                    <meta name="viewport" content="width=device-width, initial-scale=1.0">
                    <title>E-posta Doğrulama</title>
                </head>
                <body style="margin: 0; padding: 0; background-color: #1a1a1a; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; -webkit-font-smoothing: antialiased;">

                    <!-- Dış Kapsayıcı Table -->
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: #1a1a1a; padding: 40px 10px;">
                        <tr>
                            <td align="center">

                                <!-- Ana Kart (Card) Container -->
                                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="max-width: 520px; background-color: #262626; border-radius: 12px; overflow: hidden; box-shadow: 0 8px 24px rgba(0,0,0,0.5);">

                                    <!-- Header / Üst Mavi Şerit Accent -->
                                    <tr>
                                        <td style="background-color: #0078d4; height: 8px; font-size: 0; line-height: 0;">&nbsp;</td>
                                    </tr>

                                    <!-- İçerik Alanı -->
                                    <tr>
                                        <td style="padding: 40px 32px; text-align: center;">

                                            <!-- Logo / Icon -->
                                            <table border="0" cellpadding="0" cellspacing="0" align="center" style="margin-bottom: 24px;">
                                                <tr>
                                                    <td style="background-color: #0078d4; width: 64px; height: 64px; border-radius: 50%; text-align: center; vertical-align: middle;">
                                                        <!-- İkon (Email / Shield) -->
                                                        <span style="color: #ffffff; font-size: 28px; line-height: 64px; font-weight: bold;">&#10003;</span>
                                                    </td>
                                                </tr>
                                            </table>

                                            <!-- Başlık -->
                                            <h1 style="color: #ffffff; font-size: 24px; font-weight: 600; margin: 0 0 16px 0; letter-spacing: -0.5px;">
                                                Hesabınızı Doğrulayın
                                            </h1>

                                            <!-- Mesaj Metni -->
                                            <p style="color: #a0a0a0; font-size: 15px; line-height: 1.6; margin: 0 0 28px 0;">
                                                Merhaba <strong style="color: #ffffff;">{userName}</strong>,<br>
                                                Hesabınızı aktifleştirmek için aşağıdaki doğrulama butonuna tıklayabilirsiniz.
                                            </p>

                                            <!-- Buton -->
                                            <table border="0" cellpadding="0" cellspacing="0" align="center" style="margin-bottom: 24px;">
                                                <tr>
                                                    <td align="center" style="border-radius: 6px; background-color: #0078d4;">
                                                        <a href="{verificationLink}" target="_blank" style="display: inline-block; padding: 14px 32px; color: #ffffff; font-size: 15px; font-weight: 600; text-decoration: none; border-radius: 6px; transition: background-color 0.2s;">
                                                            Hesabımı Doğrula
                                                        </a>
                                                    </td>
                                                </tr>
                                            </table>

                                            <!-- Bilgilendirme Notu -->
                                            <p style="color: #666666; font-size: 13px; line-height: 1.5; margin: 0;">
                                                Bu kodu siz talep etmediyseniz lütfen bu e-postayı dikkate almayın. Kod 15 dakika boyunca geçerlidir.
                                            </p>

                                        </td>
                                    </tr>

                                    <!-- Alt Bilgi (Footer) -->
                                    <tr>
                                        <td style="background-color: #1f1f1f; padding: 20px 32px; text-align: center; border-top: 1px solid #2d2d2d;">
                                            <p style="color: #666666; font-size: 12px; margin: 0; line-height: 1.4;">
                                                &copy; 2026 isteyap. Tüm rights reserved.<br>
                                                Bu otomatik bir e-postadır, lütfen yanıtlamayınız.
                                            </p>
                                        </td>
                                    </tr>

                                </table>

                            </td>
                        </tr>
                    </table>
                </body>
                </html>
                """;

            return htmlBody;
        }
    }
}
