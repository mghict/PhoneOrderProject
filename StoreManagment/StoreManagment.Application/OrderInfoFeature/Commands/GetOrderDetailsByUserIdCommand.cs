using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class GetOrderDetailsByUserIdCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.GetOrderDetailsByUserId>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float? StoreId { get; set; }
        public int? UserId { get; set; }
    }
}
