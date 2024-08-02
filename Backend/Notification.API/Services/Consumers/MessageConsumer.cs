using Authentification.Domain.Entities;
using MassTransit;
using Notification.API.Domain.Enums;
using Notification.API.Models.Message;
using Notification.API.Services.Interfaces;
using Serilog;

namespace Notification.API.Services.Consumers
{
    public class MessageConsumer : IConsumer<UnConfirmedUser>
    {
        private readonly INotificationService notificationService;
        

        public MessageConsumer(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public async Task Consume(ConsumeContext<UnConfirmedUser> context)
        {
            var response = await notificationService.SendMessage(new NotificationMessage
            {
                Message = context.Message.Value,
                Adress = context.Message.Email
            });

            if (response.StatusCode != StatusCode.Ok)
            {
                Log.Error("Message not received");
            }
            else
            {
                Log.Information("Message successfull received");
            }
        }
    }
}
