using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("ApplicationInfoTbl")]
    public class ApplicationInfoTbl:
        BehsamFramework.Entity.IEntity<int>
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public string ApplicationName { get; set; }
        public bool Status { get; set; }
    }
}
