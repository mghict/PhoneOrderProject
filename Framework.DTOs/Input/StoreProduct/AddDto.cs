using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input.StoreProduct
{
    public class AddDto:Base.DtoInputBase
    {
        public double StoreId { get; set; }
        public int ProductId { get; set; }
        public short Quantity { get; set; }
        public DateTime ModifyDate { get; set; }
        public byte Status { get; set; }
    }
}
