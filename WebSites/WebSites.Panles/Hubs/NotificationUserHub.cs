using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace WebSites.Panles.Hubs
{

    public class NotificationUserHub:Hub
    {
        private readonly IUserConnectionManager _userConnectionManager;
        private readonly IHttpContextAccessor ContextAccessor;
        public NotificationUserHub(IUserConnectionManager userConnectionManager, IHttpContextAccessor contextAccessor)
        {
            _userConnectionManager = userConnectionManager;
            ContextAccessor = contextAccessor;
        }

        public void GetConnectionId()
        {
            var httpContext = this.Context.GetHttpContext();

            Models.UserModel user = ContextAccessor.HttpContext.Session.Get<Models.UserModel>("User");
            if(user!=null)
            {

                var userId = user.UserId;
                _userConnectionManager.KeepUserConnection(userId, Context.ConnectionId,user);
            }
            

            return ;
        }

        //Called when a connection with the hub is terminated.
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            //get the connectionId
            var connectionId = Context.ConnectionId;
            _userConnectionManager.RemoveUserConnection(connectionId);
            var value = await Task.FromResult(0);
        }
    }
}
