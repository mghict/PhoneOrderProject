using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models
{
    public class NotificationMessage
    {
        public string messageHead { get; set; }
        public string messageBody { get; set; }
        public long userId { get; set; }
        public float storeId { get; set; }
        public byte messageType { get; set; }
    }
}
