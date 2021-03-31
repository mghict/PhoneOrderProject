#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("CustomerPreOrderItemsTbl")]
    public partial class CustomerPreOrderItemsTbl : Models.Base.Entity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public short Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int TaxPrice { get; set; }
        public int DiscountPrice { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }

        public virtual CustomerPreOrderInfoTbl Order { get; set; }
        public virtual ProductInfoTbl Product { get; set; }
    }
}
