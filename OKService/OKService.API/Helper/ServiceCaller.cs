using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OKService.API.Helper
{
    public class ServiceCaller
    {
        private string Token { get; set; }
        private HttpClient client { get; set; }

        public ServiceCaller(IHttpClientFactory _clientFactory)
        {
            client = _clientFactory.CreateClient("ApiOK");
        }

        private void InitialClient()
        {

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrEmpty(Token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Token);
            }
        }

        public void SetToken(string tokenValue)
        {
            if (string.IsNullOrEmpty(tokenValue))
                Token = tokenValue;
        }

        public async Task<T> GetDataWithValue<T>(string methodName) where T : class
        {
            T resultList=default(T);

            InitialClient();

            try
            {

                var result = await client.GetAsync(methodName);
                if (result.IsSuccessStatusCode)
                {

                    var respons = await result.Content.ReadAsStringAsync();
                    resultList = JsonConvert.DeserializeObject<T>(respons);
                }
            }
            catch (Exception ex)
            {
                resultList = default(T);
            }

            return resultList;
        }

        public async Task<T> PostDataWithValue<T>(string methodName, object input) where T : class
        {
            T returnValue = default(T);

            InitialClient();

            try
            {
                var result = await client.PostAsJsonAsync(methodName, input);

                if(result.IsSuccessStatusCode)
                {
                    var respons = await result.Content.ReadAsStringAsync();
                    returnValue = JsonConvert.DeserializeObject<T>(respons);
                }
                
            }
            catch (Exception ex)
            {
                returnValue = default(T);
            }

            return returnValue;

        }

        public async Task PostDataWithoutValue(string methodName, object input)
        {
            

            InitialClient();

            try
            {
                var result = await client.PostAsJsonAsync(methodName, input);

            }
            catch (Exception ex)
            {

            }

            return;
        }
    }
}
