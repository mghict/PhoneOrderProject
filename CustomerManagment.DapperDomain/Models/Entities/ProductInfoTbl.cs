using System.Collections.Generic;

#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("ProductInfoTbl")]
    public partial class ProductInfoTbl : Models.Base.Entity
    {
        public ProductInfoTbl()
        {
            CustomerPreOrderItemsTbls = new HashSet<CustomerPreOrderItemsTbl>();
            StoreProductTbls = new HashSet<StoreProductTbl>();
        }

        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string DisplayName { get; set; }
        public string ProductName { get; set; }
        public double CategotyId { get; set; }
        public string BrandName { get; set; }
        public double UnitPrice { get; set; }
        public byte TaxPrice { get; set; }
        public int MeasureType { get; set; }
        public string ImageUrl { get; set; }
        public byte Status { get; set; }

        public virtual CategoryInfoTbl Categoty { get; set; }
        public virtual ICollection<CustomerPreOrderItemsTbl> CustomerPreOrderItemsTbls { get; set; }
        public virtual ICollection<StoreProductTbl> StoreProductTbls { get; set; }
    }
}
