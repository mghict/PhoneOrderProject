using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("StoreGeneralShippingTbl")]
    public class StoreGeneralShippingTbl:
        BehsamFramework.Entity.IEntity<byte>
    {
        [Dapper.Contrib.Extensions.Key]
        public byte Id { get; set; }
        public int ShippingPrice { get; set; }
        public int MinShippingPrice { get; set; }
    }
}
