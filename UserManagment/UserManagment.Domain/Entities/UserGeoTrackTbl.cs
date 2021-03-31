using System;

#nullable disable

namespace UserManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("UserGeoTrackTbl")]
    public partial class UserGeoTrackTbl : BehsamFramework.Entity.IEntity<int>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime ModifyDate { get; set; }

        public virtual UserInfoTbl User { get; set; }
    }
}
