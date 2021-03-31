using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AuthoManagment.Application.Security
{
    public sealed class SecurePasswordHasherHelper:ISecurePasswordHasherHelper
    {
        private readonly string _passFormat= "MGH$Behsam$1.0$";
        private readonly int _iterations= 9945005;

        private const int SaltSize = 16;
        private const int HashSize = 20;

        public SecurePasswordHasherHelper()
        {
        }

        private string Hash(string password, int iterations)
        {
            
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);
           
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(HashSize);
            
            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);
            
            var base64Hash = Convert.ToBase64String(hashBytes);
            
            return string.Format("${0}${1}${2}",_passFormat, iterations, base64Hash);
        }

        public  string Hash(string password)
        {
            return Hash(password, _iterations);
        }

        private  bool IsHashSupported(string hashString)
        {
            return hashString.Contains(_passFormat);
        }

        public  bool Verify(string password, string hashedPassword)
        {
            
            if (!IsHashSupported(hashedPassword))
            {
                throw new NotSupportedException("The HashType is not supported");
            }
            
            var splittedHashString = hashedPassword.Replace(_passFormat, "").Split('$');
            var iterations = int.Parse(splittedHashString[0]);
            if(iterations!=_iterations)
            {
                return false;
            }
            var base64Hash = splittedHashString[1];
            
            var hashBytes = Convert.FromBase64String(base64Hash);
            
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);
            
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, _iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);
            
            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
