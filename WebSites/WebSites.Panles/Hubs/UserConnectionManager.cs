using System;
using System.Collections.Generic;
using System.Linq;

namespace WebSites.Panles.Hubs
{
    public class UserConnectionManager : IUserConnectionManager
    {
        private static Dictionary<int, List<string>> userConnectionMap = new Dictionary<int, List<string>>();
        private static Dictionary<int, Models.UserModel> userDetailMap = new Dictionary<int, Models.UserModel>();
        private static Dictionary<int, List<Models.NotificationMessage>> userNotification = new Dictionary<int, List<Models.NotificationMessage>>();
        private static long notificationMessageId;

        private static string userConnectionMapLocker = string.Empty;

        public void KeepUserConnection(int userId, string connectionId, Models.UserModel user)
        {
            lock (userConnectionMapLocker)
            {
                if (!userConnectionMap.ContainsKey(userId))
                {
                    userConnectionMap[userId] = new List<string>();
                    userDetailMap[userId] = new Models.UserModel();
                }
                userConnectionMap[userId].Add(connectionId);
                userDetailMap[userId] = user;
            }
        }
        
        public void RemoveUserConnection(string connectionId)
        {
            //This method will remove the connectionId of user
            lock (userConnectionMapLocker)
            {
                foreach (var userId in userConnectionMap.Keys)
                {
                    if (userConnectionMap.ContainsKey(userId))
                    {
                        if (userConnectionMap[userId].Contains(connectionId))
                        {
                            userConnectionMap[userId].Remove(connectionId);
                            break;
                        }
                    }
                }
            }
        }
       
        public List<string> GetUserConnections(int userId)
        {
            var conn = new List<string>();
            lock (userConnectionMapLocker)
            {
                conn = userConnectionMap[userId];
            }
            return conn;
        }

        public Models.UserModel GetUserDetail(int userId)
        {
            var model = new Models.UserModel();
            lock (userConnectionMapLocker)
            {
                model = userDetailMap[userId];
            }
            return model;
        }

        public Dictionary<int, List<string>> GetConnectionMap()
        {
            var conn = new Dictionary<int, List<string>>(); 
            lock(userConnectionMapLocker)
            {
                conn= userConnectionMap;
            }

            return conn;
        }

        public Dictionary<int, Models.UserModel> GetDetailMap()
        {
            var users =new  Dictionary<int, Models.UserModel>();
            lock (userConnectionMapLocker)
            {
                users = userDetailMap;
            }
            return users;
        }

        public void SetNotification(int userId,Models.NotificationMessage message)
        {
            if (message.Id < 1)
            {
                message.Id = GetId();
            }
            message.status = true;
            if(message.CreateDate==null || message.CreateDate<DateTime.Now.AddDays(-1))
            {
                message.CreateDate = DateTime.Now;
            }

            lock (userConnectionMapLocker)
            {
                if(userConnectionMap.ContainsKey(userId))
                {
                    if(!userNotification.ContainsKey(userId))
                    {
                        userNotification[userId] = new List<Models.NotificationMessage>();
                        
                    }

                    userNotification[userId].Add(message);

                }
            }
        }

        public List<Models.NotificationMessage> GetUserNotification(int userId)
        {
            List<Models.NotificationMessage> notifications = new List<Models.NotificationMessage>();
            
            lock (userConnectionMapLocker)
            {
                if (userNotification.ContainsKey(userId))
                {
                    var messages = userNotification[userId];
                    if (messages != null)
                    {
                        notifications = userNotification[userId].Where(p=>p.status).ToList();
                    }
                }
            }

            return notifications;
        }

        public long GetId()
        {
            lock(userConnectionMapLocker)
            {
                if(long.MaxValue>notificationMessageId+1)
                {
                    notificationMessageId += 1;
                }
                else
                {
                    notificationMessageId = 1;
                }
            }
            return notificationMessageId;
        }

        public void RemoveUserNotification(int userId,long messageId)
        {
            lock(userConnectionMapLocker)
            {
                if(userNotification.ContainsKey(userId))
                {
                    var notifications = userNotification[userId];
                    if(notifications!=null)
                    {
                        foreach (var item in notifications)
                        {
                            if(item.Id==messageId)
                            {
                                notifications.Remove(item);
                            }
                        }
                        userNotification[userId] = notifications;
                    }
                }
                
            }
        }

        public void RemoveUserNotificationAll(int userId)
        {
            lock (userConnectionMapLocker)
            {
                if (userNotification.ContainsKey(userId))
                {
                    userNotification[userId] = new List<Models.NotificationMessage>();
                }

            }
        }

        public void RemoveAllUserNotification()
        {
            lock (userConnectionMapLocker)
            {
                if (userNotification!=null && userNotification.Count>0)
                {
                    foreach (var item in userNotification.Keys)
                    {
                        userNotification[item] = new List<Models.NotificationMessage>();
                    }
                }
            }
        }
    }
}
