using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;


namespace BehsamFreamwork.Logger
{
    public class LogMessage
    {
        public string ControllrName { get; set; }
        public string MethodName { get; set; }
        public string UserName { get; set; }
        public string IP { get; set; }
        public int UserId { get; set; }
        public string ActionName { get; set; }
        public DateTime CreateDate { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }

        public LogMessage()
        {
        }
        public LogMessage(string controllrName, string methodName, string userName, object body)
        {
            ControllrName = controllrName;
            MethodName = methodName;
            UserName = userName;
            IP = "";
            UserId = 0;
            ActionName = "";
            Body = body.ToJsonString();
            CreateDate = System.DateTime.Now;
            Status = "";
        }
        public LogMessage(string controllrName, string methodName, string userName, object body,string status="")
        {
            ControllrName = controllrName;
            MethodName = methodName;
            UserName = userName;
            IP = "";
            UserId = 0;
            ActionName = "";
            Body = body.ToJsonString();
            CreateDate = System.DateTime.Now;
            Status = status;
        }
        public LogMessage(string controllrName, string methodName, string userName, object body, string ip="", int userId=0, string actionName="", string status="")
        {
            ControllrName = controllrName;
            MethodName = methodName;
            UserName = userName;
            IP = ip;
            UserId = userId;
            ActionName = actionName;
            Body = body.ToJsonString();
            CreateDate = System.DateTime.Now;
            Status = status;
        }

        public string ToSerialize()
        {
           return this.ToJsonString();
        }

    }
}
