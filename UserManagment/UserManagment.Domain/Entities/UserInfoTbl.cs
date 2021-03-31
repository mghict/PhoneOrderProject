using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

#nullable disable

namespace UserManagment.Domain.Entities
{
    [Table("UserInfoTbl")]
    public partial class UserInfoTbl : BehsamFramework.Entity.IEntity<int>
    {
        public UserInfoTbl()
        {
            UserGeoTrackTbls = new HashSet<UserGeoTrackTbl>();
            UserRoleTbls = new HashSet<UserRoleTbl>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public byte Status { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<UserGeoTrackTbl> UserGeoTrackTbls { get; set; }
        public virtual ICollection<UserRoleTbl> UserRoleTbls { get; set; }
    }
}
