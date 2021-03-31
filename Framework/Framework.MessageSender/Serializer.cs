using System;
using System.Text;
using Newtonsoft.Json;

namespace Framework.MessageSender
{
    public static class Serializer
    {
        public static string ToJsonString<T>(this T input) =>
            JsonConvert.SerializeObject(input);

        public static T FromJsonString<T>(this string input) =>
            JsonConvert.DeserializeObject<T>(input);

        public static byte[] ToByteArray<T>(this T input) =>
            Encoding.UTF8.GetBytes(input.ToJsonString());

        public static T FromByteArray<T>(this byte[] input) =>
            Encoding.UTF8.GetString(input).FromJsonString<T>();
    }
}
