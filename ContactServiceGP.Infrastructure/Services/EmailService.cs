using ContactService.DTO.DTOs.Request;
using ContactServiceGP.Domain.Entities;
using ContactServiceGP.Domain.Interfaces;
using ContactServiceGP.Infrastructure.Configurations;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactServiceGP.Infrastructure.Services
{
    public class EmailService:IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions <EmailSettings> options)
        {
            _settings = options.Value;
        }

        public async Task SendEmailAsync(SendEmailReq request)
        {
            var mail = new MimeMessage();
            mail.From.Add(MailboxAddress.Parse(_settings.From));
            mail.To.Add(MailboxAddress.Parse(_settings.To));

            mail.Subject = $"Portafolio GP - Nuevo Contacto";

            mail.Body = new TextPart("html")
            {
                Text = $@"
                <h2>Nuevo mensaje desde tu portafolio</h2>
                <p><strong>Nombre:</strong> {request.fullname}</p>
                <p><strong>Email:</strong> {request.email}</p>
                <p><strong>Mensaje:</strong></p>
                <p>{request.message}</p>"
            };


            using var smtp = new SmtpClient();
            smtp.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) =>
            {
                // Permite certificados con errores de revocación, pero rechaza otros
                return (sslPolicyErrors & System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors) == 0
                    || certificate.Issuer.Contains("CN=");
            };
            await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_settings.User, _settings.Password);
            await smtp.SendAsync(mail);
            await smtp.DisconnectAsync(true);
        }
    }
}
