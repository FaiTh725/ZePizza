using MassTransit;
using Profile.Domain.Abstractions.Services;
using Profile.Domain.Enums;
using Profile.Domain.Models.Profile;
using Serilog;
using ProfileEntity = Profile.Domain.Entities.Profile;

namespace Profile.API.Infastructure.Consumers
{
    public class ProfileConsumer : IConsumer<CreateProfile>
    {
        private readonly IProfileService profileService;

        public ProfileConsumer(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        public async Task Consume(ConsumeContext<CreateProfile> context)
        {
            var response = await profileService.CreateProfile(new CreateProfile
            {
                Email = context.Message.Email,
                UserName = context.Message.UserName
            });

            if(response.StatusCode != StatusCode.Ok)
            {
                Log.Error(response.Description);
            }
            else
            {
                Log.Information(response.Description);
            }
        }
    }
}
