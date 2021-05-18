using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebSite.JourChin
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.Set(key, JsonSerializer.SerializeToUtf8Bytes(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.Get(key);

            return value == null ? default(T) :
                JsonSerializer.Deserialize<T>(value);
        }
    }

    public static class PublicExtensions
    {
        public static string EnumerableToString(this IEnumerable<string> input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in input)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    sb.AppendLine(item);
                }
            }

            return sb.ToString();
        }

        public static string ListToString(this IList<string> input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in input)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    sb.AppendLine(item);
                }
            }

            return sb.ToString();
        }

        public static string ListToStringMessage(this IList<string> input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in input)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    sb.AppendLine(item+"<br/>");
                }
            }

            return sb.ToString();
        }

        public static int ToInt(this string input)
        {
            try
            {
                return Convert.ToInt32(input);
            }
            catch
            {
                return 0;
            }
        }

        public static long ToLong(this string input)
        {
            try
            {
                return Convert.ToInt64(input);
            }
            catch
            {
                return 0;
            }
        }
    }
}
