using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizza.API.Models.Additive;
using Pizza.API.Services.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Pizza.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdditiveController : ControllerBase
    {
        private readonly IAdditiveService additiveService;

        public AdditiveController(IAdditiveService additiveService)
        {
            this.additiveService = additiveService;
        }

        [HttpGet("[action]")]
        /*[Authorize("Manager")]*/
        public async Task<IActionResult> GetAllAdditives()
        {
            var response = await additiveService.GetAllAdditives();

            return new JsonResult(response);
        }

        [HttpPost("[action]")]
        /*[Authorize("Manager")]*/
        public async Task<IActionResult> CreateAdditive(CreateAdditive request)
        {
            var response = await additiveService.CreateAdditive(request);

            return new JsonResult(response);
        }

        [HttpPut("[action]")]
        /*[Authorize("Manager")]*/
        public async Task<IActionResult> UpdateAddtitive()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("[action]")]
        /*[Authorize("Manager")]*/
        public async Task<IActionResult> DeleteAdditive(int additiveId)
        {
            var response = await additiveService.DeleteAdditive(additiveId);

            return new JsonResult(response);
        }
    } 
}
