using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Results.StoreArea
{
    public class EntityDto:Base.DtoResultBase
    {
        public int Id { get; set; }
        public double StoreId { get; set; }
        public int AreaId { get; set; }
        public int ShippingPrice { get; set; }
        public byte DrivingTime { get; set; }
        public byte Priority { get; set; }
        public byte Status { get; set; }

        public  Results.AreaInfo.EntityDto Area { get; set; }
        public Results.Store.EntityDto Store { get; set; }
    }
}
