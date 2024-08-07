using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Profile.Domain.Models.Order;

namespace Profile.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        // TODO dont know fitures for this controller may be is useless
        [HttpPut("[action]")]
        /*[Authorize]*/
        public async Task<IActionResult> UpdateProfile()
        {
            return null;
        }

        [HttpPost("[action]")]
        /*[Authorize]*/
        public async Task<IActionResult> PayOrder(CreateOrder request)
        {
            return null;
        }
    }
}
