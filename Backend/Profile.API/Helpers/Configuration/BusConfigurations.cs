namespace Profile.API.Helpers.Configuration
{
    public class BusConfigurations
    {
        public string Host { get; set; } = string.Empty;

        public int Port { get; set; }

        public string VirtualHost { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string UserPassword { get; set; } = string.Empty;
    }
}
