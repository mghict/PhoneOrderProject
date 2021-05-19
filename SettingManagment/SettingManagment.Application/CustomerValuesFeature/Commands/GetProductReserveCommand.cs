using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Application.CustomerValuesFeature.Commands
{
    public class GetProductReserveCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<BehsamFramework.Models.ProductReserveModel>
    {
        
        public long ItemId { get; set; }
        public float StoreId { get; set; }
        public bool CategoryEqual { get; set; } = true;
        public bool BrandEqual { get; set; } = false;
        public string BrandSearch { get; set; } = string.Empty;
        public bool NameEqual { get; set; } = false;
        public string NameSearch { get; set; } = string.Empty;
        public int PageNumber { get; set; } = 0;
        public int PageSize { get; set; } = 20;
    }
}
