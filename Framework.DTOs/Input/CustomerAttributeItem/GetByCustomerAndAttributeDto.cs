using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input.CustomerAttributeItem
{
    public class GetByCustomerAndAttributeDto:Base.DtoInputBase
    {
        public long CustId { get; set; }
        public int AttributeId { get; set; }
    }
}
