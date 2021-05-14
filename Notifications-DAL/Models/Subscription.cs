using System;
using System.Collections.Generic;

#nullable disable

namespace Notifications_DAL.Models
{
    public partial class Subscription
    {
        public int Id { get; set; }
        public string Endpoint { get; set; }
        public double ExpirationTime { get; set; }
        public int KeysId { get; set; }

        public virtual Keys Keys { get; set; }
    }
}
