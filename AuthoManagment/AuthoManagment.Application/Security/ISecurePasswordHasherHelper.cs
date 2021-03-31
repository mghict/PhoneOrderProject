using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthoManagment.Application.Security
{
    public interface ISecurePasswordHasherHelper
    {
        string Hash(string password);
        bool Verify(string password, string hashedPassword);
    }
}
