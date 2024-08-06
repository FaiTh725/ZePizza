
namespace Payment.Domain.Models
{
    public class CreateTransaction
    {
        public string Currency { get; set; } = string.Empty;

        public long Amount { get; set; }

        public string CustomerId { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;   
        
        public string ReceiptEmail { get; set; } = string.Empty; 
    }
}
