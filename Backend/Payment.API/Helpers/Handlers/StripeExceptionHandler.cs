using Microsoft.AspNetCore.Diagnostics;
using Payment.Domain.Enums;
using Payment.Domain.Response;
using Stripe;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace Payment.API.Helpers.Handlers
{
    public class StripeExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext, 
            Exception exception, 
            CancellationToken cancellationToken)
        {
            if(exception is StripeException)
            {

                var response = new Response
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = "Something went wrong with stripe payment"
                };

                var responseJson = JsonSerializer.Serialize(response);  

                await httpContext.Response.WriteAsJsonAsync(responseJson, cancellationToken);
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

                return true;
            }

            return false;
        }
    }
}
