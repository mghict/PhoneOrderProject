using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Application.CustomerValuesFeature.Commands
{
    public class GetStoreCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<List<BehsamFramework.Models.StoreOrderModel>>
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime RequestDate { get; set; }
        public long CustomerId { get; set; }
    }
}
