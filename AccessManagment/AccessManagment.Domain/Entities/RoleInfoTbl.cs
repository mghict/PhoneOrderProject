using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace AccessManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("RoleInfoTbl")]
    public class RoleInfoTbl:
        BehsamFramework.Entity.IEntity<int>
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
        public int ApplicationId { get; set; }
        public bool Status { get; set; }
    }
}
