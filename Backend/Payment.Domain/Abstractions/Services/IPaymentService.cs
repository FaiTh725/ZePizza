using Payment.Domain.Models;
using Payment.Domain.Response;

namespace Payment.Domain.Abstractions.Services
{
    public interface IPaymentService
    {
        Task<DataResponse<Customer>> CreateCustomer(CreateCustomer customer, CancellationToken cancellationToken = default);

        Task<DataResponse<Transaction>> CreateTransaction(CreateTransaction transaction, CancellationToken cancellationToken = default);

        Task<DataResponse<Customer>> GetCustomer(string email);
    }
}
