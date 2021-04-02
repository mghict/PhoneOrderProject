using System.Collections.Generic;

namespace WebSites.Panles.Hubs
{
    public interface IUserConnectionManager
    {
        void KeepUserConnection(int userId, string connectionId,Models.UserModel user);
        void RemoveUserConnection(string connectionId);
        List<string> GetUserConnections(int userId);
        Models.UserModel GetUserDetail(int userId);
        Dictionary<int, Models.UserModel> GetDetailMap();
        Dictionary<int, List<string>> GetConnectionMap();
        void SetNotification(int userId, Models.NotificationMessage message);
        List<Models.NotificationMessage> GetUserNotification(int userId);
        long GetId();
        void RemoveUserNotification(int userId, long messageId);
        void RemoveUserNotificationAll(int userId);
        void RemoveAllUserNotification();
    }
}
