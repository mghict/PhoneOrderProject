using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Map
{
    public class ReverseLocation
    {
        public int ID { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string formatted_address { get; set; }
        public string municipality_zone { get; set; }
        public string place { get; set; }
    }
}
