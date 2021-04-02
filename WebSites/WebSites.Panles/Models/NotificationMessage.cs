using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models
{
    public class NotificationMessage
    {
        public long Id { get; set; }
        public string messageHead { get; set; }
        public string messageBody { get; set; }
        public int userId { get; set; }
        public float storeId { get; set; }
        public bool status { get; set; }
        public byte messageType { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
