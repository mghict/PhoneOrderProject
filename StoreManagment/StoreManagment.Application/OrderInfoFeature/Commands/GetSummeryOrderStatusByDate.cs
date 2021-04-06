using System;
using System.Collections.Generic;

namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class GetSummeryOrderStatusByDate :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.GetSummeryOrderStatusByDate>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float StoreId { get; set; }
    }
}
