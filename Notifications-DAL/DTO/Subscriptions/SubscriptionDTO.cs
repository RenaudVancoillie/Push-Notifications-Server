using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications_DAL.DTO.Subscriptions
{
    public class SubscriptionDTO
    {
        public string Endpoint { get; set; }
        public float ExpirationDate { get; set; }
        public KeysDTO Keys { get; set; }
    }
}
