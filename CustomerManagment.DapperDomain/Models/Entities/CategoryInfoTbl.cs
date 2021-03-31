using System.Collections.Generic;

#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("CategoryInfoTbl")]
    public partial class CategoryInfoTbl : Models.Base.Entity
    {
        public CategoryInfoTbl()
        {
            ProductInfoTbls = new HashSet<ProductInfoTbl>();
        }

        public double Id { get; set; }
        public string CategoryName { get; set; }
        public double? ParentId { get; set; }
        public string ImageUrl { get; set; }
        public short Priority { get; set; }
        public byte Status { get; set; }

        public virtual ICollection<ProductInfoTbl> ProductInfoTbls { get; set; }
    }
}
