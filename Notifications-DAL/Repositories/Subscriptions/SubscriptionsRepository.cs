using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Notifications_DAL.Database;
using Notifications_DAL.DTO.Subscriptions;

namespace Notifications_DAL.Repositories.Subscriptions
{
    public class SubscriptionsRepository : ISubscriptionsRepository
    {
        private readonly NotificationsContext db;
        private readonly IMapper mapper;

        public SubscriptionsRepository(NotificationsContext notificationsContext,
                                       IMapper mapper)
        {
            db = notificationsContext;
            this.mapper = mapper;
        }

        public IEnumerable<SubscriptionDTO> GetAll()
        {
            return db.Subscriptions
                .ProjectTo<SubscriptionDTO>(mapper.ConfigurationProvider)
                .AsEnumerable();
        }
    }
}
