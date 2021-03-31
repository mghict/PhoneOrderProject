using System;

#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("StoreProductTbl")]
    public partial class StoreProductTbl : Models.Base.Entity
    {
        public long Id { get; set; }
        public double StoreId { get; set; }
        public int ProductId { get; set; }
        public short Quantity { get; set; }
        public DateTime ModifyDate { get; set; }
        public byte Status { get; set; }

        public virtual ProductInfoTbl Product { get; set; }
        public virtual StoreInfoTbl Store { get; set; }
    }
}
