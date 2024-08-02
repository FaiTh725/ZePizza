using Authentification.Domain.Models.User;
using Authentification.Domain.Response;
using ResponseClass = Authentification.Domain.Response.Response;

namespace Authentification.Domain.Abstractions.Services
{
    public interface IUserService
    {
        Task<DataResponse<UserResponse>> Register(RegisterUser request);

        Task<ResponseClass> StartAuthentification(string mail);

        Task<ResponseClass> GetAccessToAuthentification(string email, string value);

        Task<DataResponse<UserResponse>> Login(LoginUser request);
    }
}
