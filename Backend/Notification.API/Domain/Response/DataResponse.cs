namespace Notification.API.Domain.Response
{
    public class DataResponse<T> : Response
    {
        T Data { get; set; }
    }
}
