using Authentification.API.Infastructure.Interfaces;
using Authentification.Domain.Abstractions.Repositories;
using Authentification.Domain.Abstractions.Services;
using Authentification.Domain.Entities;
using Authentification.Domain.Enums;
using Authentification.Domain.Models.User;
using Authentification.Domain.Response;
using MassTransit;
using Profile.Domain.Entities;
using System.Text.RegularExpressions;
using Response = Authentification.Domain.Response.Response;
using ProfileEntity = Profile.Domain.Entities.Profile;
using Profile.Domain.Models.Profile;


namespace Authentification.API.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHashind passwordHashService;
        private readonly IJwtProvider jwtProvider;
        private readonly IRedisProvider cash;
        private readonly IPublishEndpoint publishEndPoint;

        public UserService(
            IUserRepository userRepository,
            IPasswordHashind passwordHashService,
            IJwtProvider jwtProvider,
            IRedisProvider cash,
            IPublishEndpoint publishEndPoint)
        {
            this.userRepository = userRepository;
            this.passwordHashService = passwordHashService;
            this.jwtProvider = jwtProvider;
            this.cash = cash;
            this.publishEndPoint = publishEndPoint;
        }

        public async Task<Response> GetAccessToAuthentification(string email, string value)
        {
            var unConfirmedUser = await cash.GetData<UnConfirmedUser>(email);

            if (unConfirmedUser == null)
            {
                return new Response
                {
                    StatusCode = StatusCode.NotFound,
                    Description = "the is not time left to registr"
                };
            }

            if (unConfirmedUser.Value == value)
            {
                await cash.DeleteData(email);

                return new Response
                {
                    StatusCode = StatusCode.Ok,
                    Description = "Provide access to auth"
                };
            }
            else
            {
                return new Response
                {
                    StatusCode = StatusCode.AuthDenied,
                    Description = "Value is not correct"
                };
            }
        }

        public async Task<DataResponse<UserResponse>> Login(LoginUser request)
        {
            var user = await userRepository.GetByEmail(request.Email);

            if (user == null)
            {
                return new DataResponse<UserResponse>
                {
                    Data = new(),
                    StatusCode = StatusCode.NotFound,
                    Description = "Current email is uneregistered"
                };
            }

            if (!passwordHashService.Verify(request.Password, user.PasswordHash))
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
            if (request.UserName == null || request.Password == null || request.Email == null)
            {
                return new DataResponse<UserResponse>
                {
                    Data = new(),
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

            if (user != null)
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

            await publishEndPoint.Publish(new CreateProfile
            {
                Email = newUser.Email,
                UserName = newUser.UserName
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

            if (user != null)
            {
                return new Response
                {
                    StatusCode = StatusCode.DataExist,
                    Description = "User alredy registered"
                };
            }

            var random = new Random();
            var randomNumbers = random.Next(0, 10000).ToString().PadLeft(4, '0');

            await cash.SetData(mail, new UnConfirmedUser
            {
                Email = mail,
                Date = DateTime.Now,
                Value = randomNumbers
            }, DateTimeOffset.Now.AddMinutes(1));

            await publishEndPoint.Publish(new UnConfirmedUser
            {
                Email = mail,
                Date = DateTime.Now,
                Value = randomNumbers
            });

            return new Response
            {
                StatusCode = StatusCode.Ok,
                Description = "Send confirm email"
            };
        }
    }
}
