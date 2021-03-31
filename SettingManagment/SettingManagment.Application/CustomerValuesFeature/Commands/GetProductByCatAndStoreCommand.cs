using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Application.CustomerValuesFeature.Commands
{
    public class GetProductByCatAndStoreCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<List<BehsamFramework.Models.ProductShowModel>>
    {
        public float CategoryId { get; set; }
        public float StoreId { get; set; }
    }
}
