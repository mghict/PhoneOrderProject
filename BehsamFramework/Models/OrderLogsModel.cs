using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehsamFramework.Models
{
    [Dapper.Contrib.Extensions.Table("OrderLogs")]
    public class OrderLogsModel:
        BehsamFramework.Entity.IEntity<long>
    {

        [Dapper.Contrib.Extensions.Key]
        public long Id { get; set; }
        public int CurrentUserId { get; set; }
        public string CurrentUserFullName { get; set; }
        public long OrderId { get; set; }
        public long OrderCode { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public int NextUserId { get; set; }
        public string NextUserFullName { get; set; }


        public OrderLogsModel()
        {
            CurrentUserFullName = "";
            OrderId = 0;
            OrderCode = 0;
            CreateDate = DateTime.Now;
            NextUserId = 0;
            NextUserFullName = "";
        }

    }
}
