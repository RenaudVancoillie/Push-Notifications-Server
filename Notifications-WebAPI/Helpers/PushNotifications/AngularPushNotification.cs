using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Notifications_WebAPI.Helpers.PushNotifications
{
    public class AngularPushNotification
    {
        private const string WRAPPER_START = "{\"notification\":";
        private const string WRAPPER_END = "}";
        private static readonly JsonSerializerSettings jsonSerializerSettings = new()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

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

        public string ToJson()
        {
            return $"{WRAPPER_START}{JsonConvert.SerializeObject(this, jsonSerializerSettings)}{WRAPPER_END}";
        }
    }
}
