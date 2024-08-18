using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizza.API.Models.Pizza;
using Pizza.API.Services.Interfaces;

namespace Pizza.API.Controllers
{

    [ApiController]
    [Route("/api[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService pizzaService;

        public PizzaController(
            IPizzaService pizzaService)
        {
            this.pizzaService = pizzaService;
        }

        [HttpPost("[action]")]
        //[Authorize(AuthenticationSchemes = "Manager")]
        //[Authorize("Manager")]
        public async Task<IActionResult> CreatePizza([FromForm]CreatePizza request)
        {
            var response = await pizzaService.CreatePizza(request);

            return new JsonResult(response);
        }

        [HttpDelete("[action]")]
        /*[Authorize("Manager")]*/
        public async Task<IActionResult> DeletePizza(int pizzaId)
        {
            var response = await pizzaService.DeletePizza(pizzaId);

            return new JsonResult(response);
        }

        [HttpPut("[action]")]
        /*[Authorize("Manager")]*/
        public async Task<IActionResult> UpdatePizza(UpdatePizza request)
        {
            throw new NotImplementedException();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPizzas()
        {
            var response = await pizzaService.GetAllPizzas();

            return new JsonResult(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPizza(int pizzaId)
        {
            var response = await pizzaService.GetPizzaById(pizzaId);

            return new JsonResult(response);
        }
    }
}
