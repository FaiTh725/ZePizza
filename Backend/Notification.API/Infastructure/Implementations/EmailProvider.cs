using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Notification.API.Helpers.Configurations;
using Notification.API.Infastructure.Interfaces;

namespace Notification.API.Infastructure.Implementations
{
    public class EmailProvider : IEmailProvider
    {
        private readonly IConfiguration configuration;

        public EmailProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendEmail(string adress, string message)
        {
            var mailConf = configuration.GetSection("MailConf").Get<MailConfiguration>();

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("ZePizza", mailConf!.Mail));
            emailMessage.To.Add(new MailboxAddress("Registration in ZePizza", adress));
            emailMessage.Subject = "ZePizza";

            // TODO сдеать красивое письмо в формате html
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = @$"<h3>{message}</h3>";

            emailMessage.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.mail.ru", 465);
            await client.AuthenticateAsync(mailConf.Mail, mailConf.SecretKey);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}
