using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Application.CustomerInfoFeature.Commands
{
    public class GetCustomerBySearchCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<BehsamFramework.Models.CustomerInfoModel>
    {
        public GetCustomerBySearchCommand()
        {

        }
        public string SearchKey { get; set; }
    }
}
