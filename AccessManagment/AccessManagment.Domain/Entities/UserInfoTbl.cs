using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Dapper;

namespace AccessManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("UserInfoTbl")]
    public class UserInfoTbl:
        BehsamFramework.Entity.IEntity<int>
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public string UserName { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public float Storeid { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
    }
}
