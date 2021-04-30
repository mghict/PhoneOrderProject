using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagement.Application.BillFeature.Commands
{
    public class GetOrderDetailCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.OrderResponse>
    {
        public long OrderCode { get; set; }
    }
}
