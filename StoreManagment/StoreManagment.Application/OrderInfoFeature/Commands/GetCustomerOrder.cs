using System;
using System.Collections.Generic;

namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class GetCustomerOrder :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long CustomerId { get; set; }
    }
}
