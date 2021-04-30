using System.Collections.Generic;

namespace StoreManagment.Application.OrderUserActiveFeature.Commands
{
    public class GetbyUserIdUserCurrentDetailsCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.CustomerPreOrderUserActive>>
    {
        public int UserId { get; set; }
    }
}
