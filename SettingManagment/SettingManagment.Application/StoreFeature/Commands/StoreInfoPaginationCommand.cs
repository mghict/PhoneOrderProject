using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreFeature.Commands
{
    public class StoreInfoPaginationCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<BehsamFramework.Models.StoreInfoListModel>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
    }
}
