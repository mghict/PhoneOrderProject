using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Dapper;

namespace SettingManagment.Domain.Entities
{

    public class Stores:BehsamFramework.Entity.IEntity<float>
    {
        public Stores()
        {

        }
        [Dapper.Contrib.Extensions.Key]
        public float StoreCode { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string StorePhone { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public string Region { get; set; }
        public string CityName { get; set; }
        public int CityId { get; set; }
        public float Distance { get; set; }
        public float sourceLatitude { get; set; }
        public float sourceLongitude { get; set; }
        public int ShippingPrice { get; set; }
    }
}
