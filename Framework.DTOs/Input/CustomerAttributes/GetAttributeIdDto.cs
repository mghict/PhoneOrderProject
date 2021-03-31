using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input.CustomerAttributes
{
    public class GetAttributeIdDto:Base.DtoInputBase
    {
        public int Id { get; set; }
        public bool? IsSortedByPriority { get; set; }
        public byte? Status { get; set; }

    }
}
