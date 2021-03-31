using System;

namespace DTOs.Input.StoreProduct
{
    public class EditDto : Base.DtoInputBase
    {
        public long Id { get; set; }
        public double StoreId { get; set; }
        public int ProductId { get; set; }
        public short Quantity { get; set; }
        public DateTime ModifyDate { get; set; }
        public byte Status { get; set; }
    }
}
