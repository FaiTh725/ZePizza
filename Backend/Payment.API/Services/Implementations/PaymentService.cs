using Payment.Domain.Abstractions.Services;
using Payment.Domain.Enums;
using Payment.Domain.Models;
using Payment.Domain.Response;
using Stripe;
using CustomerModel = Payment.Domain.Models.Customer;

namespace Payment.API.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly CustomerService customerService;
        private readonly ChargeService chargeService;
        private readonly CardService cardService;

        public PaymentService(
            CustomerService customerService,
            ChargeService chargeService,
            CardService cardService)
        {
            this.customerService = customerService;
            this.chargeService = chargeService;
            this.cardService = cardService;
        }

        public async Task<DataResponse<CustomerModel>> CreateCustomer(CreateCustomer customer, CancellationToken cancellationToken = default)
        {
            try
            {
                var options = new CustomerListOptions
                {
                    Email = customer.Email,
                };
                var service = new CustomerService();

                var customers = await service.ListAsync(options);

                if (!customers.Any())
                {
                    return new DataResponse<CustomerModel>
                    {
                        StatusCode = StatusCode.NotFound,
                        Description = "Customer with this email not found",
                        Data = new()
                    };
                }

                var customerOptions = new CustomerCreateOptions
                {
                    Name = customer.Name,
                    Email = customer.Email,
                };

                // Create customer at Stripe
                var stripeCustomer = await customerService.CreateAsync(customerOptions, null, cancellationToken);

                // Set Stripe Token options based on customer data
                var cardTokenOptions = new CardCreateOptions
                {
                    Source = "tok_visa_debit",

                };

                // Create new Card Token
                var cardToken = await cardService.CreateAsync(stripeCustomer.Id.ToString(), cardTokenOptions, null, cancellationToken);


                // if working is not test mode
                /*var options1 = new PaymentMethodCreateOptions
                {
                    Type = "card",
                    Card = new PaymentMethodCardOptions
                    {
                        Number = "4242424242424242",
                        ExpMonth = 8,
                        ExpYear = 2026,
                        Cvc = "314",
                    },
                };
                var service1 = new PaymentMethodService();
                service1.Create(options1);*/

                return new DataResponse<CustomerModel>
                {
                    StatusCode = StatusCode.Ok,
                    Description = "Success create customer",
                    Data = new CustomerModel
                    {
                        Name = stripeCustomer.Name,
                        Email = stripeCustomer.Email,
                        Id = stripeCustomer.Id,
                    }
                };
            }
            catch (StripeException)
            {
                return new DataResponse<CustomerModel>
                {
                    StatusCode = StatusCode.BadRequest,
                    Description = "Error with user credential",
                    Data = new()
                };
            }
            catch (Exception)
            {
                return new DataResponse<CustomerModel>
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = "Some wrong with service",
                    Data = new()
                };
            }
        }

        public async Task<DataResponse<Transaction>> CreateTransaction(CreateTransaction transaction, CancellationToken cancellationToken = default)
        {
            try
            {
                var chargeOptions = new ChargeCreateOptions
                {
                    Currency = transaction.Currency,
                    Amount = transaction.Amount * 100,
                    ReceiptEmail = transaction.ReceiptEmail,
                    Description = transaction.Description,
                    Customer = transaction.CustomerId
                };

                var responseTransaction = await chargeService.CreateAsync(chargeOptions, null, cancellationToken);

                return new DataResponse<Transaction>
                {
                    StatusCode = StatusCode.Ok,
                    Description = "Success execute transaction",
                    Data = new Transaction
                    {
                        Id = responseTransaction.Id,
                        Amount = responseTransaction.Amount,
                        ReceiptEmail = responseTransaction.ReceiptEmail,
                        Description = responseTransaction.Description,
                        Currency = responseTransaction.Currency,
                        CustomerId = responseTransaction.CustomerId
                    }
                };
            }
            catch (StripeException)
            {
                return new DataResponse<Transaction>
                {
                    StatusCode = StatusCode.BadRequest,
                    Description = "Error with customer data",
                    Data = new()
                };
            }
            catch (Exception)
            {
                return new DataResponse<Transaction>
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = "Some wrong with service",
                    Data = new()
                };
            }
        }

        public async Task<DataResponse<CustomerModel>> GetCustomer(string email)
        {
            var options = new CustomerListOptions
            {
                Email = email,
            };
            var service = new CustomerService();

            var customers = await service.ListAsync(options);

            if (!customers.Any())
            {
                return new DataResponse<CustomerModel>
                {
                    StatusCode = StatusCode.NotFound,
                    Description = "Customer with this email not found",
                    Data = new()
                };
            }

            return new DataResponse<CustomerModel>
            {
                StatusCode = StatusCode.Ok,
                Description = "Get customer info",
                Data = new CustomerModel
                {
                    Id = customers.First().Id,
                    Name = customers.First().Name,
                    Email = customers.First().Email,
                }
            };
        }
    }
}
