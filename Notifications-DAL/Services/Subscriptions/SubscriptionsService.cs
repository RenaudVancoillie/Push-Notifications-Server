using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Notifications_DAL.DTO.Subscriptions;
using Notifications_DAL.Repositories.Subscriptions;

namespace Notifications_DAL.Services.Subscriptions
{
    public class SubscriptionsService : ISubscriptionsService
    {
        private readonly ISubscriptionsRepository subscriptionsRepository;
        private readonly IMapper mapper;

        public SubscriptionsService(ISubscriptionsRepository subscriptionsRepository,
                                    IMapper mapper)
        {
            this.subscriptionsRepository = subscriptionsRepository;
            this.mapper = mapper;
        }

        public IEnumerable<SubscriptionDTO> GetAll() => subscriptionsRepository.GetAll();

        public SubscriptionDTO Create(SubscriptionDTO subscription) => subscriptionsRepository.Create(subscription);
    }
}
