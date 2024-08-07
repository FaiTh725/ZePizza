using Payment.Domain.Models;
using Profile.Domain.Abstractions.Repositories;
using Profile.Domain.Abstractions.Services;
using Profile.Domain.Enums;
using Profile.Domain.Models.Order;
using Profile.Domain.Models.Profile;
using Profile.Domain.Response;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using PaymentResponse = Payment.Domain.Response;
using PaymentStatusCode = Payment.Domain.Enums.StatusCode;
using ProfileEntity = Profile.Domain.Entities.Profile;

namespace Profile.API.Services.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository profileRepository;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;

        public ProfileService(
            IProfileRepository profileRepository,
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            this.profileRepository = profileRepository;
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
        }

        public async Task<DataResponse<ViewProfile>> CreateProfile(CreateProfile createProfile)
        {
            var profile = await profileRepository.GetProfileByEmail(createProfile.Email);

            if (profile != null)
            {
                return new DataResponse<ViewProfile>
                {
                    StatusCode = StatusCode.InvalidRequest,
                    Description = "Profile with such email alredy exist",
                    Data = new()
                };
            }

            profile = await profileRepository.CreateProfile(new ProfileEntity
            {
                Email = createProfile.Email,
                UserName = createProfile.UserName,
            });

            return new DataResponse<ViewProfile>
            {
                StatusCode = StatusCode.Ok,
                Description = "Profile is created",
                Data = new ViewProfile
                {
                    Id = profile.Id,
                    Email = profile.Email,
                    BirthDay = profile.BirthDay,
                    Orders = [],
                    UserName = profile.UserName
                }
            };
        }

        public async Task<DataResponse<ViewOrder>> PayOrder(CreateOrder order)
        {
            var paymentClient = httpClientFactory.CreateClient("Payment");

            var clientId = string.Empty;

            // Get ClientId
            var response = await paymentClient.GetAsync($"?email={order.EmailProfile}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<PaymentResponse.DataResponse<Customer>>(content);


                if (data == null)
                {
                    return new DataResponse<ViewOrder>
                    {
                        StatusCode = StatusCode.InternalServerError,
                        Description = "Failed with sending request to payment api",
                        Data = new()
                    };
                }

                if(data.StatusCode == PaymentStatusCode.Ok)
                {
                    clientId = data.Data.Id;
                }


                if (data.StatusCode == PaymentStatusCode.NotFound)
                {
                    var createCustomerJson = new StringContent(
                                        JsonSerializer.Serialize(new CreateCustomer
                                        {
                                            CreditCard = new(),
                                            Email = order.EmailProfile,
                                            Name = order.UserName
                                        }),
                                        Encoding.UTF8,
                                        Application.Json
                                        );

                    var responseCreateCustomer = await paymentClient.PostAsync("CreateCutomer", createCustomerJson);

                    if (response.IsSuccessStatusCode)
                    {
                        var contentCreateCustomer = await responseCreateCustomer.Content.ReadAsStringAsync();

                        var dataCreateCustomer = JsonSerializer.Deserialize<PaymentResponse.DataResponse<Customer>>(contentCreateCustomer);

                        if (dataCreateCustomer != null && dataCreateCustomer.StatusCode == PaymentStatusCode.Ok)
                        {
                            clientId = dataCreateCustomer.Data.Id;
                        }
                        else
                        {
                            return new DataResponse<ViewOrder>
                            {
                                StatusCode = StatusCode.InternalServerError,
                                Description = "Failed with create request",
                                Data = new()
                            };
                        }

                    }
                    else
                    {
                        return new DataResponse<ViewOrder>
                        {
                            StatusCode = StatusCode.InternalServerError,
                            Description = "Failed with sending request to payment api",
                            Data = new()
                        };
                    }
                }


            }
            else
            {
                return new DataResponse<ViewOrder>
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = "Failed with sending request to payment api",
                    Data = new()
                };
            }

            var executeTransactionJson = new StringContent(
                    JsonSerializer.Serialize(new CreateTransaction
                    {
                        Currency = order.Currency,
                        Amount = order.Amount,
                        CustomerId = clientId,
                        Description = order.Description,
                        ReceiptEmail = order.ReceiptEmail,
                    }),
                    Encoding.UTF8,
                    Application.Json
                );

            var transactionResponse = await paymentClient.PostAsync("ExecuteTransaction", executeTransactionJson);

            var contentTransaction = await transactionResponse.Content.ReadAsStringAsync();

            var dataTransaction = JsonSerializer.Deserialize<PaymentResponse.DataResponse<Transaction>>(contentTransaction);

            if(dataTransaction == null || dataTransaction.StatusCode != PaymentStatusCode.Ok)
            {
                return new DataResponse<ViewOrder>
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = "Failed with pay execution",
                    Data = new()
                };
            }
            else
            {
                return new DataResponse<ViewOrder>
                {
                    StatusCode = StatusCode.Ok,
                    Description = "Transaction successfull execute",
                    Data = new ViewOrder
                    {
                        CreatedDate = DateTime.UtcNow,
                        Description = dataTransaction.Data.Description,
                        Id = int.Parse(dataTransaction.Data.Id),
                        Amount = dataTransaction.Data.Amount,
                    }
                };
            }

        }

        public async Task<DataResponse<ViewProfile>> UpdateProfile(UpdateProfile updateProfile)
        {
            var profile = await profileRepository.GetProfileById(updateProfile.Id);

            if (profile == null)
            {
                return new DataResponse<ViewProfile>
                {
                    Data = new(),
                    StatusCode = StatusCode.NotFound,
                    Description = "Profile not found"
                };
            }

            var newUpdateProfile = await profileRepository.Update(profile);

            return new DataResponse<ViewProfile>
            {
                StatusCode = StatusCode.Ok,
                Description = "Profile is update",
                Data = new ViewProfile
                {
                    Id = newUpdateProfile.Id,
                    Email = newUpdateProfile.Email,
                    UserName = newUpdateProfile.UserName,
                    BirthDay = newUpdateProfile.BirthDay,
                    Orders = newUpdateProfile.Orders.Select(x => new ViewOrder
                    {
                        Id = x.Id,
                        Amount = x.Amount,
                        CreatedDate = x.CreatedDate,
                        Description = x.Description
                    }).ToList()
                }
            };
        }
    }
}
