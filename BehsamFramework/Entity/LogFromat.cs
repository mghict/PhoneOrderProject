using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehsamFramework.Entity
{
    public enum LogLevel : int
    {
        Information=0,
        Warning=1,
        Error=2,
        Critical=3,
        Trace=4,
        Debug=5,
    }

    public enum MessageLevel : int
    {
        Internal = 0,
        External = 1,
    }

    public class LogMessageBody
    {
        public string UserName { get; set; }
        public string URL { get; set; }
        public string IP { get; set; }
        public string MethodName { get; set; }
        public string ControllerName { get; set; }
        
    }
    public class LogFromat
    {
        public MessageLevel MessageLevel { get; set; }
        public LogLevel LogLevel { get; set; }
        public string MessageType { get; set; }
        public string MessageBody { get; set; }
    }
}
