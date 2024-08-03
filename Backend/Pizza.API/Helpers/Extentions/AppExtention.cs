using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Pizza.API.Helpers.Configuration;
using System.Text;

namespace Pizza.API.Helpers.Extentions
{
    public static class AppExtention
    {
        public static void AddAuthenticationConf(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConf = configuration.GetSection("JwtConfiguration").Get<JwtConfiguration>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = jwtConf!.Audience,
                        ValidIssuer = jwtConf!.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConf!.SecretKey))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["token"];

                            return Task.CompletedTask;
                        }
                    };
                });
        }

        public static void AddAuthorizationPolicyConf(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Manager", policy =>
                {
                    policy.RequireClaim("Role", "Admin", "Manager");
                });
            });
        }
    }
}
