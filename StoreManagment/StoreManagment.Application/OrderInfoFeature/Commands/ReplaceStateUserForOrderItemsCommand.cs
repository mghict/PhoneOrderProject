namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class ReplaceStateUserForOrderItemsCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public long OrderId { get; set; }
        public long ItemId { get; set; }
    }
}
