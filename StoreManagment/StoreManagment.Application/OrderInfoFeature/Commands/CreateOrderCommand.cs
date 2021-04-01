using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.Commands
{
    public class CreateOrderCommand:
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public CreateOrderCommand():base()
        {

        }
        public Domain.Entities.OrderInfo OrderInfo { get; set; }
    }
}
