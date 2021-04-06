using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class GetOrderInfoWithItemsCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.GetOrderInfoWithItems>
    {
        public long OrderCode { get; set; }
    }
}
