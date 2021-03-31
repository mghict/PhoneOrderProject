using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("EntityLog")]
    public class LogMessage:BehsamFramework.Entity.IEntity
    {
        
        public string IP { get; set; }
        public string Entity { get; set; }
        public string Action { get; set; }
        public string UserName { get; set; }
        public DateTime CreateDate { get; set; }
        public string Data{get;set; }
    }
}
