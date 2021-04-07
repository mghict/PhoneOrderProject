using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehsamFramework.Models
{
    public class StoreInfoListModel
    {
        public long RowCount { get; set; }
        public List<StoreOrderModel> Stores { get; set; }
    }

   
}
