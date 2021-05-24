namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class ChangeStateUserForOrderItemsCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public long OrderId { get; set; }
        public long ItemId { get; set; }
        public int State { get; set; }
    }
}
