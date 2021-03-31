using System.Collections.Generic;

namespace CustomerManagment.Application.CustomerAddressFeature.Commands
{
    public class GetCustomerAddressesCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<BehsamFramework.Models.CustomerAddressModel>>
    {
        public long Id { get; set; }

    }
}