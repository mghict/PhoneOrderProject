using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Results.CustomerAttribute
{
    public class EntityDto:Base.DtoResultBase
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public bool IsReuired { get; set; }
        public short Priority { get; set; }
        public byte Status { get; set; }
    }
}
