using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthoManagment.Application.Models
{
    public class LogFormat
    {
        public string MessageType { get; set; }
        public LogLevel LogLevel { get; set; }
        public string MessageBody { get; set; }
    }
}
