using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Profile.Domain.Abstractions.Services;
using Profile.Domain.Models.Order;
using Profile.Domain.Models.Profile;

namespace Profile.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        // TODO dont know fitures for this controller may be is useless
        [HttpPut("[action]")]
        /*[Authorize]*/
        public async Task<IActionResult> UpdateProfile(UpdateProfile request)
        {
            var response = profileService.UpdateProfile(request);

            return new JsonResult(response);
        }

        [HttpPost("[action]")]
        /*[Authorize]*/
        public async Task<IActionResult> PayOrder(CreateOrder request)
        {
            var response = await profileService.PayOrder(request);

            return new JsonResult(response);
        }
    }
}
