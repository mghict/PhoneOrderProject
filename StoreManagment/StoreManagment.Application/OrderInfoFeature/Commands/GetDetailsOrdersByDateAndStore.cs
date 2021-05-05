using System;
using System.Collections.Generic;

namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class GetDetailsOrdersByDateAndStore :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.GetDetailsOrdersByDateAndStore>>
    {
        public DateTime OrderDate { get; set; }
        public float StoreId { get; set; }
        public string OrderTime { get; set; }
    }
}
