
namespace Authentification.Domain.Entities
{
    public class UnConfirmedUser
    {
        public string Email { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public string Value { get; set; } = string.Empty;
    }
}
