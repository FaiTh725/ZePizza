using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Notification.API.Helpers.Configurations;
using Notification.API.Services.Consumers;
using Serilog;

namespace Notification.API.Helpers.Extentions
{
    public static class AppExtention
    {
        public static void AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var busConf = configuration.GetSection("BusConf").Get<BusConfigurations>();

            services.AddMassTransit(configuration =>
            {
                /*var asb = typeof(Program).Assembly;

                configuration.AddConsumers(asb);
                configuration.AddSagaStateMachines(asb);
                configuration.AddSagas(asb);
                configuration.AddActivities(asb);*/

                configuration.AddConsumer<MessageConsumer>();

                configuration.UsingRabbitMq((context, configurations) =>
                {
                    configurations.Host(busConf?.Host ?? "localhost",
                        (ushort)(busConf?.Port ?? 5672),
                        busConf?.VirtualHost ?? "/",
                        h =>
                        {
                            h.Username(busConf?.UserName ?? "guest");
                            h.Password(busConf?.UserPassword ?? "guest");
                        });


                    /*configurations.ReceiveEndpoint("notification", conf =>
                    {
                        conf.ConfigureConsumer<MessageConsumer>(context);
                    });

                    configurations.ClearSerialization();
                    configurations.UseRawJsonSerializer();*/
                    configurations.ConfigureEndpoints(context);
                    
                });

            });
        }

        public static void SerilogConfigure(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseSerilog((context, loggerConf) =>
            {
                loggerConf.ReadFrom.Configuration(context.Configuration);
            });
        }
    }
}
