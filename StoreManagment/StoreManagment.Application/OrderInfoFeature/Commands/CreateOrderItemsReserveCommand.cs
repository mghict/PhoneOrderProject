namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class CreateOrderItemsReserveCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<long>
    {
        public CreateOrderItemsReserveCommand() : base()
        {

        }
        public long OrderItemId { get; set; }
        public int ProductId { get; set; }
    }
}
