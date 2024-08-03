using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Pizza.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdditiveController : ControllerBase
    {
        [HttpGet("[action]")]
        [Authorize("Manager")]
        public async Task<IActionResult> GetAllAdditives()
        {
            return null;
        }

        [HttpPost("[action]")]
        [Authorize("Manager")]
        public async Task<IActionResult> CreateAdditive()
        {
            return null;
        }

        [HttpPut("[action]")]
        [Authorize("Manager")]
        public async Task<IActionResult> UpdateAddtitive()
        {
            return null;
        }

        [HttpDelete("[action]")]
        [Authorize("Manager")]
        public async Task<IActionResult> DeleteAdditive()
        {
            return null;
        }
    } 
}
