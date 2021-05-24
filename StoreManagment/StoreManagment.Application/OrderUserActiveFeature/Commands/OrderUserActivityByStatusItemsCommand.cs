using System.Collections.Generic;

namespace StoreManagment.Application.OrderUserActiveFeature.Commands
{
    public class OrderUserActivityByStatusItemsCommand :
       BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.OrderUserActivityByStatus>>
    {
        public int UserId { get; set; }
        public int Status { get; set; }
        public int ItemStatus { get; set; }
    }
}
