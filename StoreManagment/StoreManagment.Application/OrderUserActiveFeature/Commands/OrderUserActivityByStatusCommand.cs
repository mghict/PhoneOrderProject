using System.Collections.Generic;

namespace StoreManagment.Application.OrderUserActiveFeature.Commands
{
    public class OrderUserActivityByStatusCommand :
       BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.OrderUserActivityByStatus>>
    {
        public int UserId { get; set; }
        public int Status { get; set; }
    }
}
