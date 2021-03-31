using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace UserAuthorize.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("UserInfoTbl")]
    public class UserInfoTbl:
        BehsamFramework.Entity.IEntity<int>
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public long UserName { get; set; }
        public string Password { get; set; }
        public float? StoreId { get; set; }
        public bool Status { get; set; }
    }
}
