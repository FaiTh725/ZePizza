using Profile.Domain.Models.Order;
using Profile.Domain.Models.Profile;
using Profile.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Abstractions.Services
{
    public interface IProfileService
    {
        Task<DataResponse<ViewProfile>> UpdateProfile(UpdateProfile updateProfile);

        Task<DataResponse<ViewProfile>> CreateProfile(CreateProfile createProfile);

        Task<DataResponse<ViewOrder>> PayOrder(CreateOrder order);
    }
}
