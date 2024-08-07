using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfileEntity = Profile.Domain.Entities.Profile;

namespace Profile.Domain.Abstractions.Repositories
{
    public interface IProfileRepository
    {
        Task<ProfileEntity> CreateProfile(ProfileEntity profile); 

        Task<ProfileEntity> Update(ProfileEntity profile);

        Task<ProfileEntity?> GetProfileById(int id);

        Task<ProfileEntity?> GetProfileByEmail(string email);
        
    }
}
