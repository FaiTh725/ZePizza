using Microsoft.EntityFrameworkCore;
using Pizza.API.Dal.Interfaces;
using Pizza.API.Domain.Entities;
using Pizza.API.Domain.Enums;
using Pizza.API.Domain.Response;
using Pizza.API.Models.Additive;
using Pizza.API.Services.Interfaces;

namespace Pizza.API.Services.Implementations
{
    public class AdditiveService : IAdditiveService
    {
        private readonly IAdditiveRepository additiveRepository;
        private readonly IFileService fileService;
        private readonly IConfiguration configuration;

        public AdditiveService(
            IAdditiveRepository additiveRepository, 
            IFileService fileService,
            IConfiguration configuration)
        {
            this.additiveRepository = additiveRepository;
            this.fileService = fileService;
            this.configuration = configuration;
        }

        public async Task<DataResponse<ViewAdditive>> CreateAdditive(CreateAdditive additive)
        {
            var imageUrl = string.Empty;

            var uriAzure = configuration.GetConnectionString("ProxyUrl");
            var container = configuration["AzureContainers:Additive"];

            if (additive.Image != null)
            {
                using var stream = additive.Image.OpenReadStream();

                imageUrl = (await fileService.UploadFile(stream, container! , additive.Image.ContentType)).ToString();
            }

            var newAdditive = await additiveRepository.CreateAdditive(new Additive
            {
                Name = additive.Name,
                Price = additive.Price,
                ImageUrl = imageUrl,
            });

            return new DataResponse<ViewAdditive>
            {
                StatusCode = StatusCode.Ok,
                Description = "Add additive",
                Data = new ViewAdditive
                {
                    Price = newAdditive.Price,
                    Name = newAdditive.Name,
                    Id = newAdditive.Id,
                    ImageUrl = @$"{uriAzure}/{container}/{newAdditive.ImageUrl}"
                }
            };
        }

        public async Task<Response> DeleteAdditive(int id)
        {
            var additive = await additiveRepository.GetById(id);

            if(additive == null)
            {
                return new Response
                {
                    StatusCode = StatusCode.NotFound,
                    Description = "Additive not found"
                };
            }

            var container = configuration["AzureContainers:Additive"];

            await fileService.Delete(new Guid(additive.ImageUrl), container!);

            await additiveRepository.DeleteAdditive(additive);

            return new Response
            {
                StatusCode = StatusCode.Ok,
                Description = "Additive is deleted"
            };
        }

        public async Task<DataResponse<ViewAdditive>> GetAdditiveById(int id)
        {
            var additive = await additiveRepository.GetById(id);

            if(additive == null)
            {
                return new DataResponse<ViewAdditive>
                {
                    StatusCode = StatusCode.NotFound,
                    Description = "Additive not found",
                    Data = new()
                };
            }

            var uriAzure = configuration.GetConnectionString("ProxyUrl");
            var container = configuration["AzureContainers:Additive"];

            return new DataResponse<ViewAdditive>
            {
                StatusCode = StatusCode.Ok,
                Description = "Get additive",
                Data = new ViewAdditive
                {
                    Id = additive.Id,
                    Name = additive.Name,
                    ImageUrl = @$"{uriAzure}/{container}/{additive.ImageUrl}",
                    Price = additive.Price
                }
            };
        }

        public async Task<DataResponse<IEnumerable<ViewAdditive>>> GetAllAdditives()
        {
            var additives = await additiveRepository.GetAll().ToListAsync();

            var uriAzure = configuration.GetConnectionString("ProxyUrl");
            var container = configuration["AzureContainers:Additive"];

            return new DataResponse<IEnumerable<ViewAdditive>>
            {
                Description = "Get all additives",
                StatusCode = StatusCode.Ok,
                Data = additives.Select(x => new ViewAdditive
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = @$"{uriAzure}/{container}/{x.ImageUrl}",
                    Price = x.Price
                })
            };
        }
    }
}
