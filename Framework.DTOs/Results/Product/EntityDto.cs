using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Results.Product
{
    public class EntityDto:Base.DtoResultBase
    {
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

        /*public virtual CategoryInfoTbl Categoty { get; set; }
        public virtual ICollection<CustomerPreOrderItemsTbl> CustomerPreOrderItemsTbls { get; set; }
        public virtual ICollection<StoreProductTbl> StoreProductTbls { get; set; }*/
    }
}
