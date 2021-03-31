using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input.UserInfo
{
    public class LoginDto:Base.DtoInputBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
