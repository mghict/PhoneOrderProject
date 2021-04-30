using System.Collections.Generic;

namespace BillManagement.Application.BillFeature.Commands
{
    public class UpdateOrderDetailCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.OrderRequest>
    {
        public long OrderCode { get; set; }
        public List<Domain.Entities.OrderItems> OrderItems { get; set; }
    }
}
