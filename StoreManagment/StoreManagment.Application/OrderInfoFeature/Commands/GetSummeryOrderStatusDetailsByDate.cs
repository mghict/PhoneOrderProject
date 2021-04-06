using System;
using System.Collections.Generic;

namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class GetSummeryOrderStatusDetailsByDate :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float StoreId { get; set; }
        public int Status { get; set; }
    }
}
