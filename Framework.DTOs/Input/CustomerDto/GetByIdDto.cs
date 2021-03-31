using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input.CustomerDto
{
    public class GetByIdDto : Base.DtoInputBase
    {
        public long Id { get; set; }
    }
}
