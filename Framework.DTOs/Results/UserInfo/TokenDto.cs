using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Results.UserInfo
{
    public class TokenDto:DTOs.Base.DtoResultBase
    {
        public string TokenValue { get; set; }
    }
}
