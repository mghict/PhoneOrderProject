using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Application.CustomerPhoneFeature.Commands
{
    public class GetCustomerPhonesCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<List<BehsamFramework.Models.CustomerPhoneModel>>
    {
        public GetCustomerPhonesCommand()
        {

        }
        public long Id { get; set; }
    }
}
