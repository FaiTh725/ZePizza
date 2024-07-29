using Authentification.API.Domain.Enums;

namespace Authentification.API.Domain.Response
{
    public class Response
    {
        public string Description { get; set; } = string.Empty;

        public StatusCode StatusCode { get; set; }
    }
}
