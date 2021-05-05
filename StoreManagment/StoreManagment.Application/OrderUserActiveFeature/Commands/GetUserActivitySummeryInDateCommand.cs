using System.Collections.Generic;
using System;

namespace StoreManagment.Application.OrderUserActiveFeature.Commands
{
    public class GetUserActivitySummeryInDateCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.CustomerPreOrderUserActiveSummery>>
    {
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public float StoreId { get; set; }
        public int RoleId { get; set; }
    }


   
}
