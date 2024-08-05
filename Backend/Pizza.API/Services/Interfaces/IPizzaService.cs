using Pizza.API.Domain.Response;
using Pizza.API.Models.Pizza;

namespace Pizza.API.Services.Interfaces
{
    public interface IPizzaService
    {
        Task<DataResponse<ViewPizza>> GetPizzaById(int id);

        Task<DataResponse<IEnumerable<ViewPizza>>> GetAllPizzas();

        Task<Response> DeletePizza(int pizzaId);

        Task<DataResponse<ViewPizza>> UpdatePizza(UpdatePizza updatePizza);

        Task<DataResponse<ViewPizza>> CreatePizza(CreatePizza createPizza); 
    }
}
