using Authentification.API.Infastructure.Interfaces;
using BCrypt.Net;

namespace Authentification.API.Infastructure.Implementations
{
    public class PasswordHashind : IPasswordHashind
    {
        public string GenerateHash(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        public bool Verify(string password, string hash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hash, HashType.SHA384);
        }
    }
}
