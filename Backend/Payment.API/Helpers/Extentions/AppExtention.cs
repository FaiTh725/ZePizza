using Payment.API.Helpers.Configurations;
using Stripe;

namespace Payment.API.Helpers.Extentions
{
    public static class AppExtention
    {
        public static void AddPayment(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<CustomerService>();
            services.AddScoped<ChargeService>();
            services.AddScoped<CardService>();

            var paymentConf = configuration.GetSection("PaymentConf").Get<PaymentConf>();

            StripeConfiguration.ApiKey = paymentConf?.SecretKey ?? "";
        }
    }
}
