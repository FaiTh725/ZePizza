using Notification.API.Domain.Enums;

namespace Notification.API.Domain.Response
{
    public class Response
    {
        public StatusCode StatusCode { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
