namespace Authentification.API.Domain.Entities
{
    public class UnComfirmedUser
    {
        public string Email { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public string HashValue { get; set; } = string.Empty;
    }
}
