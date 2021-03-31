using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehsamFramework.Utility
{
    public class GenerateUniqueId
    {
        public static string GenerateTickId()
        {
            long i = 1;

            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }

            string number = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);

            return number;
        }

        public static string GenerateGuid()
        {
            long i = 1;
            int j = new Random().Next(100,1000);
            int f = new Random().Next(1, 1000);
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i += ((int)b * j)+f;
            }
            long r = i % 97;
            string result = i.ToString() + (98 - r).ToString("00");
            return result;
        }

        public static long GenerateGuidLong()
        {
            long i = 1;

            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }

            return i;
        }
    }
}
