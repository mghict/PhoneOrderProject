using System;

namespace SettingManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("StoreShippingAreaTbl")]
    public class StoreShippingAreaTbl:
        BehsamFramework.Entity.IEntity<int>
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public float StoreID { get; set; }
        public int AreaID { get; set; }
        public int ShippingPrice { get; set; }
        public int Priority { get; set; }
        public bool Status { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public string AreaName { get; set; }
    }
}
