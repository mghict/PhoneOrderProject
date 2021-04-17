using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Area
{
    public class AreaInfo
    {
        public long RowCount { get; set; }
        public List<Area.AreaInfoModel> Areas { get; set; }
    }
}
