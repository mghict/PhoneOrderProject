using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using WebSite.Safir.Helper;

namespace WebSite.Safir.Helper
{

    public class ServiceCaller
    {
        private string Token { get; set; }
        private HttpClient client { get; set; }

        private Settings settings { get; set; }
        //public ServiceCaller(IHttpClientFactory _clientFactory)
        //{
        //    client = _clientFactory.CreateClient("ApiGateway");

        //}
        public ServiceCaller(HttpClient HttpClient,Settings Settings)
        {
            client = HttpClient;
            settings = Settings;

            client.BaseAddress =new Uri(settings.ApiGatewayURL);

        }

        private void InitialClient()
        {

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(Token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Token);
            }

            //try
            //{
            //    var user = MyContext.HttpContext.Session.Get<Models.UserModel>("User");
            //    if (user != null)
            //    {

            //        var userName = Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(user.PhoneNumber));


            //        client.DefaultRequestHeaders.TryAddWithoutValidation("Name", userName);
            //        client.DefaultRequestHeaders.TryAddWithoutValidation("Id", user.UserId.ToString());
            //        client.DefaultRequestHeaders.TryAddWithoutValidation("IP", user.UserIp.Trim() == "::1" ? "127.0.0.1" : user.UserIp.Trim());
            //    }
            //}
            //catch
            //{

            //}

        }

        public void SetToken(string tokenValue)
        {
            if (string.IsNullOrEmpty(tokenValue))
                Token = tokenValue;
        }

        public async Task<FluentResult<T>> GetDataWithValue<T>(string methodName)
        {
            FluentResult<T> resultList = new FluentResult<T>();

            InitialClient();

            try
            {

                var result = await client.GetAsync(methodName);
                var respons = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {
                    resultList = JsonConvert.DeserializeObject<FluentResult<T>>(respons);
                }
                else
                {
                    var resultListError = JsonConvert.DeserializeObject<FluentResult>(respons);
                    resultList = new FluentResult<T>()
                    {
                        Errors = resultListError.Errors,
                        IsFailed = resultListError.IsFailed,
                        IsSuccess = resultListError.IsSuccess,
                        Successes = resultListError.Successes,
                        Value = default(T)
                    };
                }
            }
            catch (Exception ex)
            {
                resultList.WithError(ex.Message);
            }

            return resultList;
        }
        public async Task<T> GetDataWithValueAggregate<T>(string methodName)
        {
            T resultList;

            InitialClient();


            resultList = await client.GetFromJsonAsync<T>(methodName);


            return resultList;
        }
        public async Task<FluentResult<T>> PostDataWithValue<T>(string methodName, object input) //where T :class
        {
            FluentResult<T> returnValue = new FluentResult<T>();
            //T returnValue;

            InitialClient();

            try
            {
                var result = await client.PostAsJsonAsync(methodName, input);
                var respons = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {
                    
                    returnValue = JsonConvert.DeserializeObject<FluentResult<T>>(respons);
                }
                else
                {
                    var resultListError = JsonConvert.DeserializeObject<FluentResult>(respons);
                    returnValue = new FluentResult<T>()
                    {
                        Errors = resultListError.Errors,
                        IsFailed = resultListError.IsFailed,
                        IsSuccess = resultListError.IsSuccess,
                        Successes = resultListError.Successes,
                        Value = default(T)
                    };
                }
            }
            catch (Exception ex)
            {
                returnValue.WithError(ex.Message);
            }
            return returnValue;

        }
        public async Task<FluentResult> PostDataWithoutValue(string methodName, object input)
        {
            FluentResult resultList = new FluentResult();

            InitialClient();

            try
            {
                var result = await client.PostAsJsonAsync(methodName, input);

                var respons = await result.Content.ReadAsStringAsync();
                resultList = JsonConvert.DeserializeObject<FluentResult>(respons);

                if(resultList == null)
                {
                    resultList = new FluentResult();
                }

            }
            catch (Exception ex)
            {
                resultList = new FluentResult();
                resultList.WithError(ex.Message);
            }

            return resultList;
        }
    }
}
