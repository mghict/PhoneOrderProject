using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SettingManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("AreaInfoTbl")]
    public class AreaInfoTbl:
        BehsamFramework.Entity.IEntity<int>
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public string AreaName { get; set; }
        public int AreaType { get; set; }
        public int ParentID { get; set; }
        public float CenterLatitude { get; set; }
        public float Centerlongitude { get; set; }
        public bool Status { get; set; }
        public int CityId { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public string ParentName { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public string CityName { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public string AreaTypeName { get; set; }
    }

}
