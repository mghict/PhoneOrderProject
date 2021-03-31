using System;
using System.Collections.Generic;

using Dapper.Contrib.Extensions;

namespace AuthoManagment.Domain.Entities
{
    [Table("UserTbl")]
    public partial class UserInfoTbl :BehsamFramework.Entity.IEntity<int>
    {
        public UserInfoTbl():base()
        {
        }

        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public string UserName { get; set; }

    }
}
