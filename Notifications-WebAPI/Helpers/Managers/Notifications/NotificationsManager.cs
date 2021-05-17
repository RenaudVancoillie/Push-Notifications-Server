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
        private readonly string subject;
        private readonly string publicKey;
        private readonly string privateKey;

        private readonly WebPushClient webPushClient;

        public NotificationsManager(IConfiguration configuration)
        {
            subject = configuration.GetSection("subject").Value;
            publicKey = configuration.GetSection("publicKey").Value;
            privateKey = configuration.GetSection("privateKey").Value;
            webPushClient = new WebPushClient();
        }

        public void SendNotification(SubscriptionDTO subscription, string message)
        {
            PushSubscription pushSubscription = new(subscription.Endpoint, 
                subscription.Keys.P256dh, subscription.Keys.Auth);
            VapidDetails vapidDetails = new(subject, publicKey, privateKey);
            webPushClient.SendNotification(pushSubscription, message, vapidDetails);
        }
    }
}
