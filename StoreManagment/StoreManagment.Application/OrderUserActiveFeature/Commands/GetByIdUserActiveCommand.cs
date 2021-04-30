namespace StoreManagment.Application.OrderUserActiveFeature.Commands
{
    public class GetByIdUserActiveCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.CustomerPreOrderUserActive>
    {
        public long Id { get; set; }
    }
}
