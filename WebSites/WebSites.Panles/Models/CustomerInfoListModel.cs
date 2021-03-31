using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models
{
    public class CustomerInfoListModel
    {
        public long RowCount { get; set; }
        public List<Models.CustomerInfoModel> CustomerInfos { get; set; }
    }
}
