using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Results.CustomerAttributeItem
{
    public class EntityDto:Base.DtoResultBase
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public int AttributeId { get; set; }
        public string AttributeValue { get; set; }
        public byte Status { get; set; }
    }
}
