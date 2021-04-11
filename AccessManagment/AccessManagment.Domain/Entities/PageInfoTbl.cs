using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("PageInfoTbl")]
    public class PageInfoTbl:
        BehsamFramework.Entity.IEntity<int>
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public string PageName { get; set; }
        public string DisplayName { get; set; }
        public int ApplicationId { get; set; }
        public int ParentId { get; set; }
        public bool Status { get; set; }
    }
}
