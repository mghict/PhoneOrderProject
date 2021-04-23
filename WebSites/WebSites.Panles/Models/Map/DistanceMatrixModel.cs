using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Map
{
    public class DistanceMatrixModel
    {
        public string Status { get; set; }
        public List<Element> rows { get; set; }
        public List<string> origin_addresses { get; set; }
        public List<string> destination_addresses { get; set; }
    }
}
