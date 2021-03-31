using System;

namespace BehsamFramework.Util
{
    public static class Converter
    {
        public static int ToInt(this object input)
        {
            try
            {
                return Convert.ToInt32(input);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}