using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("CityTbl")]
    public class CityTbl:
        BehsamFramework.Entity.IEntity<int>
    {
        public int Id { get; set; }
        public float CityId { get; set; }
        public string CityName { get; set; }
        public int ProvinceId { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public string ProvinceName { get; set; }
    }
}
