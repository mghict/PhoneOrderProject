using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Order
{
    public interface IMessageService
    {

    }
    public class MessageService : Base.ServiceBase, IMessageService
    {
        List<Models.NotificationMessage> Messages = new List<Models.NotificationMessage>();
        public MessageService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        void CreateMessage(Models.NotificationMessage model)
        {
            string key = "NotificationMessage";
            Messages=CacheService.GetOrSet(Messages,
                    key,
                    TimeSpan.FromDays(1),
                    TimeSpan.FromHours(8),
                    CacheItemPriority.NeverRemove,
                    TokenCachClass.CachedMessageToken);

            if(Messages==null || Messages.Count<1)
            {
                Messages = new List<Models.NotificationMessage>();
            }

            Messages.Add(model);
        }
    }
}
