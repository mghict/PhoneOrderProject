using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehsamFramework.Util.Middleware
{
    public class LoggingMiddlewareOptions
    {
        public string ServiceName { set; get; }

        public LoggingMiddlewareOptions(string serviceName)
        {
            ServiceName = serviceName;
        }
    }
}
