using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Application.CustomerInfoFeature.Commands
{
    public class GetAllCustomerCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<BehsamFramework.Models.CustomerInfoListModel>
    {
        public GetAllCustomerCommand()
        {

        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
    }
}
