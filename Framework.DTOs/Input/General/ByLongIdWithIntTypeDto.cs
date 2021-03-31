using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input.General
{
    public class ByLongIdWithIntTypeDto:Base.DtoInputBase
    {
        public long Id { get; set; }
        public int Type { get; set; }
    }
}
