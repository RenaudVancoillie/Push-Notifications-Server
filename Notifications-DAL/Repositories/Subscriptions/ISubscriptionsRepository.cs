using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notifications_DAL.DTO.Subscriptions;

namespace Notifications_DAL.Repositories.Subscriptions
{
    public interface ISubscriptionsRepository
    {
        SubscriptionDTO GetById(int id);
        IEnumerable<SubscriptionDTO> GetAll();
        SubscriptionDTO Create(SubscriptionDTO subscription);
    }
}
