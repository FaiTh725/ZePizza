using Authentification.Domain.Enums;

namespace Authentification.Domain.Response
{
    public class Response
    {
        public string Description { get; set; } = string.Empty;

        public StatusCode StatusCode { get; set; }
    }
}
