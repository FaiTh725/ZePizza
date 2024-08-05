using Pizza.API.Domain.Response;
using Pizza.API.Models.Additive;

namespace Pizza.API.Services.Interfaces
{
    public interface IAdditiveService
    {
        Task<DataResponse<ViewAdditive>> CreateAdditive(CreateAdditive additive);

        Task<DataResponse<IEnumerable<ViewAdditive>>> GetAllAdditives();

        Task<DataResponse<ViewAdditive>> GetAdditiveById(int id);

        Task<Response> DeleteAdditive(int id);
    }
}
