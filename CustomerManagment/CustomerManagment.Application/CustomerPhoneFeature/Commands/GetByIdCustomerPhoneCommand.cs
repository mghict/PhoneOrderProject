using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Application.CustomerPhoneFeature.Commands
{
    public class GetByIdCustomerPhoneCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<BehsamFramework.Models.CustomerPhoneModel>
    {
        public GetByIdCustomerPhoneCommand()
        {

        }
        public long Id { get; set; }
    }
}
