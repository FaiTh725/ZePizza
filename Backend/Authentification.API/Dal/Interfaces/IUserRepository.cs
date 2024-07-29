using Authentification.API.Domain.Entities;

namespace Authentification.API.Dal.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Create(User user);

        Task<User?> GetByEmail(string email);
    }
}
