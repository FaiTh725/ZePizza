using Microsoft.EntityFrameworkCore;
using Profile.Domain.Abstractions.Repositories;
using ProfileEntity = Profile.Domain.Entities.Profile;

namespace Profile.API.Dal.Implementations
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly AppDbContext context;

        public ProfileRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<ProfileEntity> CreateProfile(ProfileEntity profile)
        {
            var profileEntity = await context.Profiles.AddAsync(profile);
        
            await context.SaveChangesAsync();

            return profileEntity.Entity;
        }

        public async Task<ProfileEntity?> GetProfileByEmail(string email)
        {

            return await context.Profiles.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<ProfileEntity?> GetProfileById(int id)
        {
            return await context.Profiles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProfileEntity> Update(ProfileEntity profile)
        {
            var oldProfile = await context.Profiles.FirstOrDefaultAsync(x => x.Id == profile.Id);
        
            oldProfile.BirthDay = profile.BirthDay;
            oldProfile.UserName = profile.UserName;

            await context.SaveChangesAsync();

            return oldProfile;
        }
    }
}
