using Authentification.API.Domain.Response;
using Authentification.API.Models.User;

namespace Authentification.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<DataResponse<UserResponse>> Register(RegisterUser request);

        Task<Response> StartAuthentification(string mail);

        Task<DataResponse<UserResponse>> Login(LoginUser request);
    }
}
