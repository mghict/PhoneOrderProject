using System.Collections.Generic;

namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class GetOrderItemsReserveDetailsCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.OrderItemsReserve>>
    {
        public long ItemId { get; set; }
    }
}
