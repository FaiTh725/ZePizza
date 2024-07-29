using Pizza.API.Domain.Enums;

namespace Pizza.API.Domain.Response
{
    public class Response
    {
        public string Description { get; set; } = string.Empty;

        public StatusCode StatusCode { get; set; }
    }
}
