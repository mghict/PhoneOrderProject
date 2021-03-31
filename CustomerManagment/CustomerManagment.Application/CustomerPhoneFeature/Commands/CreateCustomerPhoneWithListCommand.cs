using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Application.CustomerPhoneFeature.Commands
{
    public class CreateCustomerPhoneWithListCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<List<BehsamFramework.Models.CustomerPhoneModel>>
    {
        public CreateCustomerPhoneWithListCommand():base()
        {

        }
        public long CustomerId { get; set; }
        public int PhoneType { get; set; }
        public long PhoneValue { get; set; }
        public byte Status { get; set; }
    }
}
