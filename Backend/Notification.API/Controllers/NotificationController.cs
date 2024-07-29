using Microsoft.AspNetCore.Mvc;
using Notification.API.Models.Message;
using Notification.API.Services.Interfaces;

namespace Notification.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService notificationService;

        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> SendEmailConfirm([FromQuery] NotificationMessage request)
        {
            var response = await notificationService.SendMessage(request);

            return new JsonResult(response);
        }
    }
}
