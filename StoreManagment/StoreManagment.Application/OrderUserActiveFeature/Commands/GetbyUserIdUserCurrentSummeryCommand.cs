using System.Collections.Generic;

namespace StoreManagment.Application.OrderUserActiveFeature.Commands
{
    public class GetbyUserIdUserCurrentSummeryCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.CustomerPreOrderUserActiveSummery>>
    {
        public int UserId { get; set; }
    }
}
