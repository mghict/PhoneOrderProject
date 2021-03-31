using System;

#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("UserGeoTrackTbl")]
    public partial class UserGeoTrackTbl : Models.Base.Entity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime ModifyDate { get; set; }

        public virtual UserInfoTbl User { get; set; }
    }
}
