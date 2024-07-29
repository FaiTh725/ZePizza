using Authentification.API.Dal.Interfaces;
using Authentification.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Authentification.API.Dal.Impelentations
{
    public class Userrepository : IUserRepository
    {
        private readonly AppDbContext context;

        public Userrepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<User> Create(User user)
        {
            var result = await context.Users.AddAsync(user);

            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Email == email);  
        }
    }
}
