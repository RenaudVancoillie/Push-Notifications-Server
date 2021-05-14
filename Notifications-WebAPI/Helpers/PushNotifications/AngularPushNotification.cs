using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications_WebAPI.Helpers.PushNotifications
{
    public class AngularPushNotification
    {
        public AngularPushNotification()
        {
            Vibrate = new List<int>();
            Actions = new List<NotificationAction>();
        }

        public string Title { get; set; }
        public string Body { get; set; }
        public string Icon { get; set; }
        public IList<int> Vibrate { get; set; }
        public IDictionary<string, object> Data { get; set; }
        public IList<NotificationAction> Actions { get; set; }
    }
}
