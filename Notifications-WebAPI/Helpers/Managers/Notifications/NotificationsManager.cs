using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Notifications_DAL.DTO.Subscriptions;
using WebPush;

namespace Notifications_WebAPI.Helpers.Managers.Notifications
{
    public class NotificationsManager : INotificationsManager
    {
        private readonly VapidDetails vapidDetails;
        private readonly WebPushClient webPushClient;

        public NotificationsManager(IConfiguration configuration)
        {
            IConfigurationSection vapidConfiguration = configuration.GetSection("VAPID");
            string subject = vapidConfiguration.GetSection("Subject").Value;
            string publicKey = vapidConfiguration.GetSection("PublicKey").Value;
            string privateKey = vapidConfiguration.GetSection("PrivateKey").Value;
            vapidDetails = new(subject, publicKey, privateKey);
            webPushClient = new WebPushClient();
        }

        public void SendNotification(SubscriptionDTO subscription, string message)
        {
            PushSubscription pushSubscription = new(subscription.Endpoint, 
                subscription.Keys.P256dh, subscription.Keys.Auth);
            webPushClient.SendNotification(pushSubscription, message, vapidDetails);
        }
    }
}
