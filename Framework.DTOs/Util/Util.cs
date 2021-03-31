using System;
using System.Linq;


namespace DTOs
{
    public class Util
    {


        public static string CustomerCode()
        {
            //var rnd = new Random(DateTime.Now.Ticks.GetHashCode());
            //var myNumber = rnd.Next(1, 999999999);

            //var str = myNumber.ToString();
            //var num = Convert.ToInt64(str);
            //num = num % 97;
            //num = 98 - num;
            //str = num + str;

            var i = new Guid();
            i = Guid.NewGuid();

            return i.ToString().GetHashCode().ToString("x") ;

            // return str;
        }

        public static bool IsLetter(string value)
        {
            value = value.Replace(" ", string.Empty);
            return value.All(char.IsLetter);
        }

        public static bool IsDigit(string value)
        {
            value = value.Replace(" ", string.Empty);
            return value.All(char.IsDigit);
        }

        public static bool IsDigit(byte value)
        {
            string Values = value.ToString();
            Values = Values.Replace(" ", string.Empty);
            return Values.All(char.IsDigit);
        }

        public static bool IsDigit(int value)
        {
            string Values = value.ToString();
            Values = Values.Replace(" ", string.Empty);
            return Values.All(char.IsDigit);
        }

        public static bool IsDigit(long value)
        {
            string Values = value.ToString();
            Values = Values.Replace(" ", string.Empty);
            return Values.All(char.IsDigit);
        }

        public static bool IsDigit(object value)
        {
            string Values = value.ToString();
            Values = Values.Replace(" ", string.Empty);
            return Values.All(char.IsDigit);
        }

        public static bool IsDecimals(object value)
        {
            string Values = value.ToString();
            Values = Values.Replace(" ", string.Empty);
            int dotCount = Values.Where(c => c.Equals(".")).Count();
            if (dotCount != 1)
            {
                return false;
            }
            Values = Values.Replace(".", string.Empty);
            return Values.All(char.IsDigit);
        }

        public static bool IsDecimals(float value)
        {
            string Values = value.ToString();
            Values = Values.Replace(" ", string.Empty);
            int dotCount = Values.Where(c => c.Equals(".")).Count();
            if (dotCount != 1)
            {
                return false;
            }
            Values = Values.Replace(".", string.Empty);
            return Values.All(char.IsDigit);
        }

        public static bool IsDecimals(decimal value)
        {
            string Values = value.ToString();
            Values = Values.Replace(" ", string.Empty);
            int dotCount = Values.Where(c => c.Equals(".")).Count();
            if (dotCount != 1)
            {
                return false;
            }
            Values = Values.Replace(".", string.Empty);
            return Values.All(char.IsDigit);
        }

        public static bool IsDecimals(double value)
        {
            string Values = value.ToString();
            try
            {
                double temp = Convert.ToDouble(value.ToString());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            //Values = Values.Replace(" ", string.Empty).Replace(",", ".");
            //int dotCount = Values.Where(c => c.Equals(".")).Count();
            //if (dotCount != 1)
            //{
            //    return false;
            //}
            //Values = Values.Replace(".", string.Empty);
            //return Values.All(char.IsDigit);
        }
    }
}
