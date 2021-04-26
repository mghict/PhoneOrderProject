using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class ChangeOrderStatusCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public long OrderCode { get; set; }
        public byte Status { get; set; }
        public string Reason { get; set; }
    }
}
