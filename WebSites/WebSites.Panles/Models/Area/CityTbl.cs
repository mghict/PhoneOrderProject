using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Area
{
  
    public class CityTbl
    {
        public int Id { get; set; }
        public float CityId { get; set; }
        public string CityName { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
    }
}
