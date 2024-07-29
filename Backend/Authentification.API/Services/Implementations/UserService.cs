using Authentification.API.Dal.Interfaces;
using Authentification.API.Domain.Entities;
using Authentification.API.Domain.Enums;
using Authentification.API.Domain.Response;
using Authentification.API.Infastructure.Interfaces;
using Authentification.API.Models.User;
using Authentification.API.Services.Interfaces;
using System.Text.RegularExpressions;

namespace Authentification.API.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHashind passwordHashService;
        private readonly IJwtProvider jwtProvider;
        private readonly ICashProvider cash;

        public UserService(
            IUserRepository userRepository,
            IPasswordHashind passwordHashService,
            IJwtProvider jwtProvider,
            ICashProvider cash)
        {
            this.userRepository = userRepository;
            this.passwordHashService = passwordHashService;
            this.jwtProvider = jwtProvider;
            this.cash = cash;
        }

        public async Task<DataResponse<UserResponse>> Login(LoginUser request)
        {
            var user = await userRepository.GetByEmail(request.Email);

            if(user == null)
            {
                return new DataResponse<UserResponse>
                {
                    Data = new(),
                    StatusCode = StatusCode.NotFound,
                    Description = "Current email is uneregistered"
                };
            }

            if(!passwordHashService.Verify(request.Password, user.PasswordHash))
            {
                return new DataResponse<UserResponse>
                {
                    Data = new(),
                    StatusCode = StatusCode.NotFound,
                    Description = "Error in email or password"
                };
            }

            var token = jwtProvider.GenerateToken(user);

            return new DataResponse<UserResponse>
            {
                Data = new()
                {
                    Token = token,
                },
                StatusCode = StatusCode.Ok,
                Description = "Successfull login"
            };
        }

        public async Task<DataResponse<UserResponse>> Register(RegisterUser request)
        {
            if(request.UserName == null || request.Password == null || request.Email == null)
            {
                return new DataResponse<UserResponse>
                {
                    Data = new (),
                    Description = "All fileds are required",
                    StatusCode = StatusCode.InvalidData
                };
            }

            if (request.Password.Length < 6)
            {
                return new DataResponse<UserResponse>
                {
                    Data = new(),
                    StatusCode = StatusCode.InvalidData,
                    Description = "Password should containe minimum 5 simbols"
                };
            }

            if (!Regex.IsMatch(request.Password, @"\d") || !Regex.IsMatch(request.Password, @"[a-zA-Z]"))
            {
                return new DataResponse<UserResponse>
                {
                    Data = new(),
                    StatusCode = StatusCode.InvalidData,
                    Description = "Password should contain minimum one letter and one number"
                };
            }

            var user = await userRepository.GetByEmail(request.Email);

            if(user != null)
            {
                return new DataResponse<UserResponse>
                {
                    Data = new(),
                    StatusCode = StatusCode.DataExist,
                    Description = "Current Email is registered"
                };
            }

            var passwordHash = passwordHashService.GenerateHash(request.Password);

            var newUser = await userRepository.Create(new User
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                UserName = request.UserName,
            });

            var token = jwtProvider.GenerateToken(newUser);

            return new DataResponse<UserResponse>
            {
                StatusCode = StatusCode.Ok,
                Description = "New user are created success",
                Data = new UserResponse
                {
                    Token = token
                }
            };
        }

        public async Task<Response> StartAuthentification(string mail)
        {
            var user = await userRepository.GetByEmail(mail);

            if(user != null)
            {
                return new Response
                {
                    StatusCode = StatusCode.DataExist,
                    Description = "User alredy registered"
                };
            }

            await cash.SetData(mail, new UnComfirmedUser
            {
                Email = mail,
                Date = DateTime.Now,
                HashValue = "hui"
            });

            var data = await cash.GetData<UnComfirmedUser>(mail);

            return null;
        }
    }
}
