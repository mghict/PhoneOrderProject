using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Results
{
    public class CustomerInfoDto:Base.DtoResultBase
    {
        public long Id { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public int CustomerTypeId { get; set; }
        public int CustomerGroupId { get; set; }
        public long WaletPrice { get; set; }
        public int Score { get; set; }
        public int RegisterTypeId { get; set; }
        public DateTime RegisterDate { get; set; }
        public TimeSpan RegisterTime { get; set; }
        public byte Status { get; set; }
    }
}
