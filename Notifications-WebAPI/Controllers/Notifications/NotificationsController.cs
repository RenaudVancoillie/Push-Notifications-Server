using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notifications_DAL.DTO.Subscriptions;
using Notifications_DAL.Services.Subscriptions;
using Notifications_WebAPI.Helpers.Managers.Notifications;
using Notifications_WebAPI.Helpers.PushNotifications;

namespace Notifications_WebAPI.Controllers.Notifications
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly ISubscriptionsService subscriptionsService;
        private readonly INotificationsManager notificationsManager;

        public NotificationsController(ISubscriptionsService subscriptionsService,
                                       INotificationsManager notificationsManager)
        {
            this.subscriptionsService = subscriptionsService;
            this.notificationsManager = notificationsManager;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AngularPushNotification), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public ActionResult<AngularPushNotification> SendNotification([FromBody] AngularPushNotification notification)
        {
            try
            {
                string message = JsonSerializer.Serialize(notification);
                foreach (SubscriptionDTO subscription in subscriptionsService.GetAll())
                {
                    notificationsManager.SendNotification(subscription, message);
                }
                return Ok(notification);
            }
            catch (Exception exc)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Something went wrong: {exc.Message}");
            }
        }
    }
}
