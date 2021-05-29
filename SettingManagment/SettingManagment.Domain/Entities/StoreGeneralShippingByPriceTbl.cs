using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("StoreGeneralShippingByPriceTbl")]
    public class StoreGeneralShippingByPriceTbl:
        BehsamFramework.Entity.IEntity<int>
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public int FromSum { get; set; }
        public int ToSum { get; set; }
        public int ShippingPrice { get; set; }
        public bool Status { get; set; }
    }
}
