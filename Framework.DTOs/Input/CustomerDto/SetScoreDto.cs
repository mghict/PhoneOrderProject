using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input.CustomerDto
{
    public class SetScoreDto:Base.DtoInputBase
    {
        public int Score { get; set; }
        public long Id { get; set; }
    }
}
