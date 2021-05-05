using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class GetSummeryOrdersByDateAndStore:
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.GetSummeryOrdersByDateAndStore>>
    {
        public DateTime OrderDate { get; set; }
        public float StoreId { get; set; }
    }
}
