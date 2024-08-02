using Authentification.Domain.Entities;

namespace Authentification.Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User> Create(User user);

        Task<User?> GetByEmail(string email);
    }
}
