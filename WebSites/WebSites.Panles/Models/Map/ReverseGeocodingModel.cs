using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Map
{
    public class ReverseGeocodingModel
    {
        public string status { get; set; }
        public string formatted_address { get; set; }
        public string route_name { get; set; }
        public string route_type { get; set; }
        public string neighbourhood { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string place { get; set; }
        public string municipality_zone { get; set; }
        public string in_traffic_zone { get; set; }
        public string in_odd_even_zone { get; set; }
        public List<Addresse> addresses { get; set; }
    }
}
