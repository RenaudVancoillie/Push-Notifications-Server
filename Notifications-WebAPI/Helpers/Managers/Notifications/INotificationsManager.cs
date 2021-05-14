using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notifications_DAL.DTO.Subscriptions;

namespace Notifications_WebAPI.Helpers.Managers.Notifications
{
    public interface INotificationsManager
    {
        void SendNotification(SubscriptionDTO subscription, string message);
    }
}
