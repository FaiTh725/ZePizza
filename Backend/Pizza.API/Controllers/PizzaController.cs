using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizza.API.Models.Pizza;
using Pizza.API.Services.Interfaces;

namespace Pizza.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService pizzaService;
        //TODO delete continue
        private readonly IFileService fileService;

        public PizzaController(
            IPizzaService pizzaService,
            IFileService fileService)
        {
            this.pizzaService = pizzaService;
            this.fileService = fileService;
        }

        [HttpPost("[action]")]
        /*[Authorize("Manager")]*/
        public async Task<IActionResult> CreatePizza([FromForm]CreatePizza request)
        {
            Guid fileId = Guid.Empty;

            if(request.Image != null)
            {
                using var stream = request.Image.OpenReadStream();

                fileId = await fileService.UploadFile(stream, request.Image.ContentType);
            }

            return Ok(fileId.ToString());
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
