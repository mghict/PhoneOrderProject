using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Application.CustomerPhoneFeature.Commands
{
    public class CreateCustomerPhoneCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<long>
    {
        public CreateCustomerPhoneCommand()
        {
            
        }

        public long CustomerId { get; set; }
        public int PhoneType { get; set; }
        public long PhoneValue { get; set; }
        public byte Status { get; set; }
    }
}
