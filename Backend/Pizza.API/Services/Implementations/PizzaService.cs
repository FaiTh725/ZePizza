using Microsoft.EntityFrameworkCore;
using Pizza.API.Dal.Interfaces;
using Pizza.API.Domain.Entities;
using Pizza.API.Domain.Enums;
using Pizza.API.Domain.Response;
using Pizza.API.Models.Additive;
using Pizza.API.Models.Pizza;
using Pizza.API.Services.Interfaces;
using static CSharpFunctionalExtensions.Result;
using PizzaEntity = Pizza.API.Domain.Entities.Pizza;

namespace Pizza.API.Services.Implementations
{
    // TODO may be integrated automapper for pizza
    // TODO optimize response entity for pizza forexample delete list of additive
    // TODO Set containers name and uri like readonly
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository pizzaRepository;
        private readonly IFileService fileService;
        private readonly IConfiguration configuration;

        public PizzaService(
            IPizzaRepository pizzaRepository,
            IFileService fileService,
            IConfiguration configuration)
        {
            this.pizzaRepository = pizzaRepository;
            this.fileService = fileService;
            this.configuration = configuration;
        }

        public async Task<DataResponse<ViewPizza>> CreatePizza(CreatePizza createPizza)
        {
            var imageUrl = string.Empty;

            var uriAzure = configuration.GetConnectionString("ProxyUrl");
            var containerPizza = configuration["AzureContainers:Pizza"];
            var containerAdditive = configuration["AzureContainers:Additive"];

            if (createPizza.Image != null)
            {
                using var stream = createPizza.Image.OpenReadStream();

                imageUrl = (await fileService.UploadFile(stream, containerPizza!, createPizza.Image.ContentType)).ToString();
            }

            var newPizza = await pizzaRepository.CreatePizzaWithExistAdditive(new PizzaEntity
            {
                Name = createPizza.Name,
                BasePrice = createPizza.BasePrice,
                Description = createPizza.Description,
                NutritionalValue = createPizza.NutritionalValue,
                Radius = createPizza.Radius,
                Sizetype = createPizza.Sizetype,
                DoughType = createPizza.DoughType,
                Weight = createPizza.Weight,
                ImageUrl = imageUrl,
                Additives = createPizza.IdAdditives.Select(x => new Additive { Id = x }).ToList()
            });


            return new DataResponse<ViewPizza>
            {
                Description = "Pizza is create",
                StatusCode = StatusCode.Ok,
                Data = new ViewPizza
                {
                    Id = newPizza.Id,
                    Name = newPizza.Name,
                    BasePrice = newPizza.BasePrice,
                    Description = newPizza.Description,
                    DoughType = newPizza.DoughType,
                    Weight = newPizza.Weight,
                    ImageUrl = @$"{uriAzure}/{containerPizza}/{newPizza.ImageUrl}",
                    Radius = newPizza.Radius,
                    Sizetype = newPizza.Sizetype,
                    NutritionalValue = newPizza.NutritionalValue,
                    IdAdditives = newPizza.Additives.Select(x => new ViewAdditive
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Price = x.Price,
                        ImageUrl = @$"{uriAzure}/{containerAdditive}/{x.ImageUrl}"
                    }).ToList()
                }
            };
        }

        public async Task<Response> DeletePizza(int pizzaId)
        {
            var pizza = await pizzaRepository.GetPizzaById(pizzaId);

            if(pizza == null)
            {
                return new Response
                {
                    StatusCode = StatusCode.NotFound,
                    Description = "Pizza is not found",
                };
            }

            var containerPizza = configuration["AzureContainers:Pizza"];

            await fileService.Delete(new Guid(pizza.ImageUrl), containerPizza!);

            await pizzaRepository.DeletePizza(pizza);

            return new Response
            {
                StatusCode = StatusCode.Ok,
                Description = "Pizza deleting success"
            };
        }

        public async Task<DataResponse<IEnumerable<ViewPizza>>> GetAllPizzas()
        {
            var pizzas = await pizzaRepository.GetPizzas().ToListAsync();

            var uriAzure = configuration.GetConnectionString("ProxyUrl");
            var containerPizza = configuration["AzureContainers:Pizza"];
            var containerAdditive = configuration["AzureContainers:Additive"];

            return new DataResponse<IEnumerable<ViewPizza>>
            {
                StatusCode = StatusCode.Ok,
                Description = "Get all pizzas",
                Data = pizzas.Select(x => new ViewPizza
                {
                    Id = x.Id,
                    Name = x.Name,
                    BasePrice = x.BasePrice,
                    Description = x.Description,
                    DoughType = x.DoughType,
                    NutritionalValue = x.NutritionalValue,
                    Radius = x.Radius,
                    Sizetype = x.Sizetype,
                    Weight = x.Weight,
                    ImageUrl = @$"{uriAzure}/{containerPizza}/{x.ImageUrl}",
                    IdAdditives = x.Additives.Select(y => new ViewAdditive
                    {
                        Id = y.Id,
                        Name = y.Name,
                        Price = y.Price,
                        ImageUrl = @$"{uriAzure}/{containerAdditive}/{y.ImageUrl}"
                    }).ToList()
                })
            };
        }

        public async Task<DataResponse<ViewPizza>> GetPizzaById(int id)
        {
            var pizza = await pizzaRepository.GetPizzaById(id);

            if(pizza == null)
            {
                return new DataResponse<ViewPizza>
                {
                    StatusCode = StatusCode.NotFound,
                    Description = "Pizza not found",
                    Data = new()
                };
            }

            var uriAzure = configuration.GetConnectionString("ProxyUrl");
            var containerPizza = configuration["AzureContainers:Pizza"];
            var containerAdditive = configuration["AzureContainers:Additive"];

            return new DataResponse<ViewPizza>
            {
                StatusCode = StatusCode.Ok,
                Description = "Get all pizzas",
                Data = new ViewPizza
                {
                    Id = pizza.Id,
                    Name = pizza.Name,
                    BasePrice = pizza.BasePrice,
                    Description = pizza.Description,
                    DoughType = pizza.DoughType,
                    NutritionalValue = pizza.NutritionalValue,
                    Radius = pizza.Radius,
                    Sizetype = pizza.Sizetype,
                    Weight = pizza.Weight,
                    ImageUrl = @$"{uriAzure}/{containerPizza}/{pizza.ImageUrl}",
                    IdAdditives = pizza.Additives.Select(y => new ViewAdditive
                    {
                        Id = y.Id,
                        Name = y.Name,
                        Price = y.Price,
                        ImageUrl = @$"{uriAzure}/{containerAdditive}/{y.ImageUrl}"
                    }).ToList()
                }
            };
        }

        public Task<DataResponse<ViewPizza>> UpdatePizza(UpdatePizza updatePizza)
        {
            throw new NotImplementedException();
        }
    }
}
