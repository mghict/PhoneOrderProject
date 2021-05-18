namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class UpdateOrderItemsReserveCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public UpdateOrderItemsReserveCommand() : base()
        {

        }
        public long Id { get; set; }
        public long OrderItemId { get; set; }
        public int ProductId { get; set; }
        public bool Status { get; set; }
    }
}
