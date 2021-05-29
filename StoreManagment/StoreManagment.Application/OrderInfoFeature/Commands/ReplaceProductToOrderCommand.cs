namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class ReplaceProductToOrderCommand :
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public ReplaceProductToOrderCommand() : base()
        {

        }
        public long OrginalItemId { get; set; }
        public int ReplaceProductId { get; set; }
        public int Count { get; set; }
    }
}
