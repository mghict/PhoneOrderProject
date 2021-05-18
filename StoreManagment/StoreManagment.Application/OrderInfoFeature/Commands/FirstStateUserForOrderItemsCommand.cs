namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class FirstStateUserForOrderItemsCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public long OrderId { get; set; }
        public long ItemId { get; set; }
    }
}
