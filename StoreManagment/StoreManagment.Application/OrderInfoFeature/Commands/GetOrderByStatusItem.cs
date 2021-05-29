using System.Collections.Generic;

namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class GetOrderByStatusItem :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.OrderByStatusItem>>
    {
        public int UserId { get; set; }
        public int Status { get; set; }
        public int ItemStatus { get; set; }
    }
}
