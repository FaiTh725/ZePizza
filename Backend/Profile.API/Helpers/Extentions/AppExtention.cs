using MassTransit;
using Profile.API.Helpers.Configuration;
using Profile.API.Infastructure.Consumers;
using Profile.Domain.Models.Profile;
using Serilog;

namespace Profile.API.Helpers.Extentions
{
    public static class AppExtention
    {
        public static void AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var busConf = configuration.GetSection("BusConfiguration").Get<BusConfigurations>();

            services.AddMassTransit(configuration =>
            {
                configuration.AddConsumer<ProfileConsumer>();

                configuration.UsingRabbitMq((context, configurations) =>
                {
                    configurations.Host(
                        busConf.Host,
                        (ushort)busConf.Port,
                        busConf.VirtualHost,
                        h =>
                        {
                            h.Username(busConf.UserName);
                            h.Password(busConf.UserPassword);
                        });

                    configurations.ConfigureEndpoints(context);
                });
            });
        }

        public static void AddHttpClients(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddHttpClient("Payment", conf =>
            {
                conf.BaseAddress = new Uri($"{configuration["APIUri:Payment"]}/api/Payment");
            });
        }

        public static void AddSerilog(this IHostBuilder hostBuilder) 
        {
            hostBuilder.UseSerilog((context, conf) =>
            {
                conf.ReadFrom.Configuration(context.Configuration);
            });
        }
    }
}
