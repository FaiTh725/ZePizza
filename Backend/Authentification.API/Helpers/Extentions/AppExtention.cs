using Authentification.API.Helpers.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Authentification.API.Helpers.Extentions
{
    public static class AppExtention
    {
        public static void AddApiAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtConf = configuration.GetSection("JwtConf").Get<JwtConfigurations>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = jwtConf.Audience,
                        ValidIssuer = jwtConf.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConf.SecretKey))
                    };

                    // On Default by request checking only header for authentification token 
                    // this code check cookies for authntification token also
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["token"];

                            return Task.CompletedTask;
                        }
                    };

                    
                });

            // token should containt claim with key test and value true
            services.AddAuthorization(options =>
            {
                options.AddPolicy("test", policy =>
                {
                    policy.RequireClaim("test", "true", "false");
                });
            });

            services.AddAuthorization();
        }

        public static void AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            var redisConnection = configuration.GetConnectionString("RedisConnection");

            services.AddStackExchangeRedisCache(redisOptions =>
            {
                redisOptions.Configuration = redisConnection;
            });
        }
    }
}
