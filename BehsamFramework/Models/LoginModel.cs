using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehsamFramework.Models
{
    public class LoginModel
    {
        public LoginModel()
        {
            Token = "";
        }
        public LoginModel(string token)
        {
            Token = token;
        }
        public string Token { get; set; }
    }
}
