using Microsoft.EntityFrameworkCore;
using Pizza.API.Dal.Interfaces;
using Pizza.API.Domain.Entities;

namespace Pizza.API.Dal.Implementations
{
    public class AdditiveRepository : IAdditiveRepository
    {
        private readonly AppDbContext context;

        public AdditiveRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Additive> CreateAdditive(Additive additive)
        {
            var additivEntity = await context.Additives.AddAsync(additive);

            await context.SaveChangesAsync();

            return additivEntity.Entity;
        }

        public async Task DeleteAdditive(Additive additive)
        {
            context.Additives.Remove(additive);

            await context.SaveChangesAsync();
        }

        public IQueryable<Additive> GetAll()
        {
            return context.Additives.Include(x => x.Pizzas);
        }

        public async Task<Additive?> GetById(int id)
        {
            return await context.Additives.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
