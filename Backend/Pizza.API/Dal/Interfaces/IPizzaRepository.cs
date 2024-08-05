using PizzaEntity = Pizza.API.Domain.Entities.Pizza;

namespace Pizza.API.Dal.Interfaces
{
    public interface IPizzaRepository
    {
        IQueryable<PizzaEntity> GetPizzas();

        Task<PizzaEntity?> GetPizzaByIdWithIncludes(int id);

        Task<PizzaEntity?> GetPizzaById(int id);

        Task DeletePizza(PizzaEntity pizza);

        Task<PizzaEntity> UpdatePizza(PizzaEntity pizza);

        Task<PizzaEntity> CreatePizza(PizzaEntity pizza);

        Task<PizzaEntity> CreatePizzaWithExistAdditive(PizzaEntity pizza);
    }
}
