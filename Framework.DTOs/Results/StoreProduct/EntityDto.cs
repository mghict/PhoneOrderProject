using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Results.StoreProduct
{
    public class EntityDto:Base.DtoResultBase
    {
        public long Id { get; set; }
        public double StoreId { get; set; }
        public int ProductId { get; set; }
        public short Quantity { get; set; }
        public DateTime ModifyDate { get; set; }
        public byte Status { get; set; }

        public Results.Product.EntityDto Product { get; set; }
        public Results.Store.EntityDto Store { get; set; }
    }
}
