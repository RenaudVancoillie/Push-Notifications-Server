using System;
using System.Collections.Generic;

#nullable disable

namespace Notifications_DAL.Models
{
    public partial class Keys
    {
        public Keys()
        {
            Subscriptions = new HashSet<Subscription>();
        }

        public int Id { get; set; }
        public string P256dh { get; set; }
        public string Auth { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
