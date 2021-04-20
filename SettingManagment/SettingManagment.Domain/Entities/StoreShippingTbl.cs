using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SettingManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("StoreShippingTbl")]
    public class StoreShippingTbl:
        BehsamFramework.Entity.IEntity<int>
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public float StoreID { get; set; }
        public int ShippingPrice { get; set; }
        public bool Status { get; set; }
    }
}
