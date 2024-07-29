namespace Notification.API.Infastructure.Interfaces
{
    public interface IEmailProvider
    {
        Task SendEmail(string adress, string message);
    }
}
