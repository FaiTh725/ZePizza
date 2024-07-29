using Notification.API.Domain.Response;
using Notification.API.Models.Message;

namespace Notification.API.Services.Interfaces
{
    public interface INotificationService
    {
        Task<Response> SendMessage(NotificationMessage notification);
    }
}
