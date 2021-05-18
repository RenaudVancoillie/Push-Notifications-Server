using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Notifications_DAL.DTO.Subscriptions;
using Notifications_DAL.Services.Subscriptions;
using WebPush;

namespace Notifications_WebAPI.Helpers.Managers.Notifications
{
    public class NotificationsManager : INotificationsManager
    {
        private readonly VapidDetails vapidDetails;
        private readonly WebPushClient webPushClient;

        private readonly ISubscriptionsService subscriptionsService;

        public NotificationsManager(IConfiguration configuration,
                                    ISubscriptionsService subscriptionsService)
        {
            IConfigurationSection vapidConfiguration = configuration.GetSection("VAPID");
            string subject = vapidConfiguration.GetSection("Subject").Value;
            string publicKey = vapidConfiguration.GetSection("PublicKey").Value;
            string privateKey = vapidConfiguration.GetSection("PrivateKey").Value;
            vapidDetails = new(subject, publicKey, privateKey);
            webPushClient = new WebPushClient();
            this.subscriptionsService = subscriptionsService;
        }

        public void SendNotification(SubscriptionDTO subscription, string message)
        {
            try
            {
                PushSubscription pushSubscription = new(subscription.Endpoint,
                    subscription.Keys.P256dh, subscription.Keys.Auth);
                webPushClient.SendNotification(pushSubscription, message, vapidDetails);
            }
            catch (WebPushException)
            {
                // Subscription has expired or is no longer valid and should be removed.
            }
        }
    }
}
