using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebSite.Safir
{
    public static class CustomeHttpClientExtension
    {
        public static async Task<T> GetJsonAsync<T>(this HttpClient httpClient, string requestUri)
        {
            var httpContent = await httpClient.GetAsync(requestUri);
            string jsonContent =await httpContent.Content.ReadAsStringAsync();
            T obj = JsonConvert.DeserializeObject<T>(jsonContent);
            httpContent.Dispose();
            return obj;
        }
    }
}
