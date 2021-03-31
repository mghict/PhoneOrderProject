using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BehsamFreamwork.Logger
{
    public class LogMessage
    {
        public string ControllrName { get; set; }
        public string MethodName { get; set; }
        public string UserName { get; set; }
        public string Body { get; set; }

        public LogMessage()
        {
                
        }
        public LogMessage(string controllrName, string methodName, string userName, string body)
        {
            ControllrName = controllrName;
            MethodName = methodName;
            UserName = userName;
            Body = body;
        }


        public string ToSerialize()
        {
           return this.ToJsonString();
        }

    }
}
