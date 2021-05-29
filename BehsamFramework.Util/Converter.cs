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
        public static int ToInt(this string input)
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
        public static byte ToByte(this string input)
        {
            try
            {
                return Convert.ToByte(input);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}