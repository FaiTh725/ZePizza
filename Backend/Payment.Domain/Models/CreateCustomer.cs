
namespace Payment.Domain.Models
{
    public class CreateCustomer
    {
        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;    

        public CreditCard CreditCard { get; set; }
    }
}
