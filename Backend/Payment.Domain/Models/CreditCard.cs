
namespace Payment.Domain.Models
{
    public class CreditCard
    {
        public string Name { get; set; } = string.Empty;

        public string Number { get; set; } = string.Empty;

        public string ExpiryYear { get; set; } = string.Empty;

        public string ExpiryMonth { get; set; } = string.Empty;

        public string Cvc { get; set; } = string.Empty;


    }
}
