using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace WebSites.Panles.Models.Area
{
    public class AreaGeoTbl
    {
        public long Id { get; set; }
        public int AreaId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public bool Status { get; set; }
    }
}
