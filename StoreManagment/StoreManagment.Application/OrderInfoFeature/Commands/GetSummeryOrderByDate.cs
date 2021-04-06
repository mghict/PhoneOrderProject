using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class GetSummeryOrderByDate:
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.GetSummeryOrderByDate>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
