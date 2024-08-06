using Microsoft.AspNetCore.Mvc;
using Payment.Domain.Abstractions.Services;
using Payment.Domain.Models;

namespace Payment.API.Controllers
{
    // TODO setting jwt auth to communicate to this service
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;

        public PaymentController(
            IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCustomer(CreateCustomer request)
        {
            var response = await paymentService.CreateCustomer(request);

            return new JsonResult(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ExecuteTransaction(CreateTransaction request)
        {
            var response = await paymentService.CreateTransaction(request);

            return new JsonResult(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomerId(string email)
        {
            var response = await paymentService.GetCustomer(email);

            return new JsonResult(response);
        }
    }
}
