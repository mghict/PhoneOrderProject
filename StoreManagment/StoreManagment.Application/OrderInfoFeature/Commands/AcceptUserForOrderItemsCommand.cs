namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class AcceptUserForOrderItemsCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public long OrderId { get; set; }
        public long ItemId { get; set; }
    }
}
