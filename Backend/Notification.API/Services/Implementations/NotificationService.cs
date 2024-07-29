using MailKit.Net.Smtp;
using MimeKit;
using Notification.API.Domain.Enums;
using Notification.API.Domain.Response;
using Notification.API.Helpers.Configurations;
using Notification.API.Infastructure.Interfaces;
using Notification.API.Models.Message;
using Notification.API.Services.Interfaces;

namespace Notification.API.Services.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly IEmailProvider emailProvider;

        public NotificationService(IEmailProvider emailProvider)
        {
            this.emailProvider = emailProvider;
        }

        public async Task<Response> SendMessage(NotificationMessage notification)
        {
            try
            {
                await emailProvider.SendEmail(notification.Adress, notification.Message);

                return new Response
                {
                    Description = "Successful sending email",
                    StatusCode = StatusCode.Ok
                };
            }
            catch
            {
                return new Response
                {
                    Description = "Some error when sending email",
                    StatusCode = StatusCode.ServerError
                };
            }
        }
    }
}
