using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input.CustomerDto
{
    public class EditDto : Base.DtoInputBase
    {
        public long Id { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public int CustomerTypeId { get; set; }
        public int CustomerGroupId { get; set; }
        public int RegisterTypeId { get; set; }
        public byte Status { get; set; }
    }
}
