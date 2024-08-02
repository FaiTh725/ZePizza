namespace Authentification.API.Helpers.Configurations
{
    public class BusConfigurations
    {
        public string Host {  get; set; } = string.Empty;

        public int Port { get; set; } = 5672;

        public string VirtualHost {  get; set; } = string.Empty;

        public string UserName {  get; set; } = string.Empty;   

        public string UserPassword {  get; set; } = string.Empty;
    }
}
