using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Application.CustomerInfoFeature.Commands
{
    public class GetByIdCustomerCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<BehsamFramework.Models.CustomerInfoModel>
    {
        public GetByIdCustomerCommand():base()
        {
            
        }

        public long Id { get; set; }

    }
}
