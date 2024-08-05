using Microsoft.EntityFrameworkCore;
using Pizza.API.Dal.Interfaces;
using Pizza.API.Domain.Entities;
using PizzaEntity = Pizza.API.Domain.Entities.Pizza;

namespace Pizza.API.Dal.Implementations
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly AppDbContext context;

        public PizzaRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<PizzaEntity> CreatePizza(PizzaEntity pizza)
        {
            var pizzaEntity = await context.Pizzas.AddAsync(pizza);
            
            await context.SaveChangesAsync();

            return pizzaEntity.Entity;
        }

        public async Task<PizzaEntity> CreatePizzaWithExistAdditive(PizzaEntity pizza)
        {
            /*var transacton = context.Database.BeginTransaction();*/

            context.Additives.AttachRange(pizza.Additives);

            return await CreatePizza(pizza);
        }

        public async Task DeletePizza(PizzaEntity pizzaEntity)
        {
            context.Pizzas.Remove(pizzaEntity);

            await context.SaveChangesAsync();
        }

        public async Task<PizzaEntity?> GetPizzaById(int id)
        {
            return await context.Pizzas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PizzaEntity?> GetPizzaByIdWithIncludes(int id)
        {
            return await context.Pizzas
                .Include(x => x.Additives)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<PizzaEntity> GetPizzas()
        {
            return context.Pizzas.Include(x => x.Additives);
        }

        public async Task<PizzaEntity> UpdatePizza(PizzaEntity pizza)
        {
            var oldPizza = await GetPizzaByIdWithIncludes(pizza.Id);

            oldPizza.DoughType = pizza.DoughType;
            oldPizza.Radius = pizza.Radius;
            oldPizza.Sizetype = pizza.Sizetype;
            oldPizza.BasePrice = pizza.BasePrice;
            oldPizza.Description = pizza.Description;
            oldPizza.ImageUrl = pizza.ImageUrl;
            oldPizza.Name = pizza.Name;
            oldPizza.NutritionalValue = pizza.NutritionalValue;
            oldPizza.Weight = pizza.Weight;

            var additives = new List<Additive>(pizza.Additives);

            oldPizza.Additives = additives;

            return oldPizza;
        }
    }
}
