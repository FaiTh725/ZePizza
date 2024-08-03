using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizza.API.Services.Interfaces;

namespace Pizza.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            this.pizzaService = pizzaService;
        }

        [HttpPost("[action]")]
        [Authorize("Manager")]
        public async Task<IActionResult> CreatePizza()
        {
            return null;
        }

        [HttpDelete("[action]")]
        [Authorize("Manager")]
        public async Task<IActionResult> DeletePizza()
        {
            return null;
        }

        [HttpPut("[action]")]
        [Authorize("Manager")]
        public async Task<IActionResult> UpdatePizza()
        {
            return null;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPizzas()
        {
            return null;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPizza()
        {
            return null;
        }
    }
}
