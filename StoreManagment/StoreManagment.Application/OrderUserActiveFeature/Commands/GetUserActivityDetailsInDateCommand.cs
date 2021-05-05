using System.Collections.Generic;

namespace StoreManagment.Application.OrderUserActiveFeature.Commands
{
    public class GetUserActivityDetailsInDateCommand :
       BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.CustomerPreOrderUserActive>>
    {
        public int UserId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public float StoreId { get; set; }
    }
}
