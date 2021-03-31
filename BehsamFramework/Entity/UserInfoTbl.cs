using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

#nullable disable

namespace BehsamFramework.Entity
{
    [Table("UserInfoTbl")]
    public partial class UserInfoTbl : IEntity<int>
    {
        public UserInfoTbl()
        {
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime RegisterDate { get; set; }
        public byte Status { get; set; }
        public string UserName { get; set; }
    }
}
