using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WebSites.Panles.Hubs;

namespace WebSites.Panles.Services.Notification
{
    public interface INotificationService
    {
        void CreateGeneralNotification(Models.NotificationMessage message);
        void CreateUserNotification(Models.NotificationMessage message);
        void CreateStoreNotification(Models.NotificationMessage message);
        List<Models.NotificationMessage> GetUserNotifications(int userId);

    }
    public class NotificationService: INotificationService
    {
        private readonly IHubContext<NotificationUserHub> _notificationUserHubContext;
        private readonly IHubContext<NotificationHub> _notificationHubContext;
        private readonly IUserConnectionManager _userConnectionManager;

        public NotificationService(IHubContext<NotificationUserHub> notificationUserHubContext, IHubContext<NotificationHub> notificationHubContext, IUserConnectionManager userConnectionManager)
        {
            _notificationUserHubContext = notificationUserHubContext;
            _notificationHubContext = notificationHubContext;
            _userConnectionManager = userConnectionManager;
        }

        public void CreateGeneralNotification(Models.NotificationMessage message)
        {
            Task.Run(async() =>
            {
                message.Id = _userConnectionManager.GetId();

                await _notificationUserHubContext.Clients.All.SendAsync("sendToUser", message.messageHead, message.messageBody, message.messageType);

                var connections = _userConnectionManager.GetConnectionMap();
                foreach (var item in connections.Keys)
                {
                    _userConnectionManager.SetNotification(item, message);
                }

            });
            
        }

        public void CreateUserNotification(Models.NotificationMessage message)
        {
            Task.Run(async () =>
            {
                message.Id = _userConnectionManager.GetId();

                var connections = _userConnectionManager.GetUserConnections(message.userId);
                if(connections!=null && connections.Count>0)
                {
                    foreach(var connection in connections)
                    {
                        await _notificationUserHubContext.Clients.Client(connection).SendAsync("sendToUser", message.messageHead, message.messageBody, message.messageType);
                    }
                    _userConnectionManager.SetNotification(message.userId, message);
                }
            });

        }

        public void CreateStoreNotification(Models.NotificationMessage message)
        {
            Task.Run(async () =>
            {
                message.Id = _userConnectionManager.GetId();

                var users = _userConnectionManager.GetDetailMap();
                if(users!=null && users.Count>0)
                {
                    foreach (var item in users.Keys)
                    {
                        var userinfo = users[item] as Models.UserModel;
                        if(userinfo!=null && userinfo.StoreId!=null && userinfo.StoreId==message.storeId.ToString(CultureInfo.InvariantCulture))
                        {
                            var connections = _userConnectionManager.GetUserConnections(userinfo.UserId);
                            if (connections != null && connections.Count > 0)
                            {
                                foreach (var connection in connections)
                                {
                                    await _notificationUserHubContext.Clients.Client(connection).SendAsync("sendToUser", message.messageHead, message.messageBody, message.messageType);
                                }

                                _userConnectionManager.SetNotification(userinfo.UserId, message);
                            }
                        }

                    }
                }

                
            });

        }

        public List<Models.NotificationMessage> GetUserNotifications(int userId)
        {
            return _userConnectionManager.GetUserNotification(userId);
        }
    }
}
