using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Notifications_DAL.DTO.Subscriptions;
using Notifications_DAL.Models;

namespace Notifications_WebAPI.Mappings
{
    public class SubscriptionProfile : Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<Subscription, SubscriptionDTO>();
            CreateMap<Keys, KeysDTO>();
        }
    }
}
