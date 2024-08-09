using Authentification.Domain.Enums;
using Authentification.Domain.Response;
using Microsoft.AspNetCore.Diagnostics;
using StackExchange.Redis;

namespace Authentification.API.Helpers.Handlers
{
    public class RedisConHandlerException : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext, 
            Exception exception, 
            CancellationToken cancellationToken)
        {
            if(exception is RedisConnectionException)
            {
                var response = new Response
                {
                    Description = "Redis is not connected",
                    StatusCode = StatusCode.ServerError
                };

                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await httpContext.Response.WriteAsJsonAsync(response);

                return true;
            }

            return false;
        }
    }
}
