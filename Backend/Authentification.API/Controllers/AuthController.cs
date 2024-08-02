using Authentification.Domain.Abstractions.Services;
using Authentification.Domain.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace Authentification.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Login([FromQuery]LoginUser request)
        {
            var response = await userService.Login(request);

            if (response.StatusCode == Domain.Enums.StatusCode.Ok)
            {
                HttpContext.Response.Cookies.Append(
                    "token",
                    response.Data!.Token);
            }

            return new JsonResult(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> StartAuthentification(string mail)
        {
            var response = await userService.StartAuthentification(mail);

            return new JsonResult(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ContinueAuthentification(string email, string value)
        {
            var response = await userService.GetAccessToAuthentification(email, value);   
        
            return new JsonResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser request)
        {
            var response = await userService.Register(request);

            if(response.StatusCode == Domain.Enums.StatusCode.Ok)
            {
                HttpContext.Response.Cookies.Append(
                    "token",
                    response.Data!.Token);
            }

            return new JsonResult(response);
        }
    }
}
