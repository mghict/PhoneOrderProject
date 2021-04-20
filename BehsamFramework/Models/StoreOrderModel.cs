using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehsamFramework.Models
{
    public class StoreOrderModel
    {
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
        public string StatusStr { get; set; }
    }
}
