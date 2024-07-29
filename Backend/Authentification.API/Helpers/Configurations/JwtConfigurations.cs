namespace Authentification.API.Helpers.Configurations
{
    public class JwtConfigurations
    {
        public string SecretKey { get; set; }

        public string Audience { get; set; }

        public string Issuer { get; set; }
    }
}
