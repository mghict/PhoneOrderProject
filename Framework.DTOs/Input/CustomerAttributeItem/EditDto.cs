using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input.CustomerAttributeItem
{
    public class EditDto:Base.DtoInputBase
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public int AttributeId { get; set; }
        public string AttributeValue { get; set; }
        public byte Status { get; set; }
    }
}
