using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications_WebAPI.Helpers.PushNotifications
{
    public class NotificationAction
    {
        public NotificationAction(string action, string title, string icon)
        {
            Action = action;
            Title = title;
            Icon = icon;
        }

        public string Action { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}
