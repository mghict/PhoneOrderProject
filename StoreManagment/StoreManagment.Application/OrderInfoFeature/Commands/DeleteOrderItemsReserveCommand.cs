namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class DeleteOrderItemsReserveCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public DeleteOrderItemsReserveCommand() : base()
        {

        }
        public long Id { get; set; }
    }
}
