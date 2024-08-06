using Payment.Domain.Enums;

namespace Payment.Domain.Response
{
    public class Response
    {
        public string Description { get; set; } = string.Empty;

        public StatusCode StatusCode { get; set; }
    }
}
