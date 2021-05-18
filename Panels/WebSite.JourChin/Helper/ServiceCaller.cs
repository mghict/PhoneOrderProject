using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.JourChin.Helper
{
    public class ServiceCaller
    {
        private string Token { get; set; }
        private HttpClient client { get; set; }
        private IHttpContextAccessor MyContext;
        private System.Text.Json.JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy=System.Text.Json.JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy=System.Text.Json.JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive=true,
            IgnoreReadOnlyProperties=false,
            IgnoreNullValues=false,
            WriteIndented=true
        };

        private JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
            
        };
        public ServiceCaller(IHttpClientFactory _clientFactory, IHttpContextAccessor myContext)
        {
            client = _clientFactory.CreateClient("ApiGateway");
            MyContext = myContext;
        }

        private void InitialClient()
        {

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(Token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Token);
            }

            try
            {
                var user = MyContext.HttpContext.Session.Get<Models.UserModel>("User");
                if (user != null)
                {

                    var userName = Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(user.PhoneNumber));


                    client.DefaultRequestHeaders.TryAddWithoutValidation("Name", userName);
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Id", user.UserId.ToString());
                    client.DefaultRequestHeaders.TryAddWithoutValidation("IP", user.UserIp.Trim() == "::1" ? "127.0.0.1" : user.UserIp.Trim());
                }
            }
            catch
            {

            }

        }

        public void SetToken(string tokenValue)
        {
            if (string.IsNullOrEmpty(tokenValue))
                Token = tokenValue;
        }

        //----------------------------------------------
        //----------------------------------------------

        public async Task<FluentResults.Result<T>> GetDataWithValue<T>(string methodName)
        {
            FluentResults.Result<T> resultList = new FluentResults.Result<T>();

            InitialClient();

            try
            {

                var result = await client.GetAsync(methodName);
                var respons = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {

                    //var fluentResult = System.Text.Json.JsonSerializer.Deserialize<FluentResult<T>>(respons, jsonSerializerOptions);
                    var fluentResult = JsonConvert.DeserializeObject<FluentResult<T>>(respons);
                    resultList = Convert<T>(fluentResult);
                }
                else
                {
                    var resultListError = JsonConvert.DeserializeObject<FluentResult>(respons);
                    //var resultListError = System.Text.Json.JsonSerializer.Deserialize<FluentResult>(respons, jsonSerializerOptions);
                    resultList = Convert<T>(resultListError);
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
        public async Task<FluentResults.Result<T>> PostDataWithValue<T>(string methodName, object input) //where T :class
        {
            FluentResults.Result<T> returnValue = new FluentResults.Result<T>();
            //T returnValue;

            InitialClient();

            try
            {
                var result = await client.PostAsJsonAsync(methodName, input);
                var respons = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {

                    //var fluentResult = System.Text.Json.JsonSerializer.Deserialize<FluentResult<T>>(respons,jsonSerializerOptions);
                    var fluentResult = JsonConvert.DeserializeObject<FluentResult<T>>(respons);
                    returnValue = Convert<T>(fluentResult);
                }
                else
                {
                    var resultListError = JsonConvert.DeserializeObject<FluentResult>(respons);
                   // var resultListError = System.Text.Json.JsonSerializer.Deserialize<FluentResult>(respons, jsonSerializerOptions);
                    returnValue = Convert<T>(resultListError);

                }
            }
            catch (Exception ex)
            {
                returnValue.WithError(ex.Message);
            }
            return returnValue;

        }
        public async Task<FluentResults.Result> PostDataWithoutValue(string methodName, object input)
        {
            FluentResults.Result resultList = new FluentResults.Result();

            InitialClient();

            try
            {
                var result = await client.PostAsJsonAsync(methodName, input);

                var respons = await result.Content.ReadAsStringAsync();

                //var fluentResult = System.Text.Json.JsonSerializer.Deserialize<FluentResult>(respons, jsonSerializerOptions);
                var fluentResult = JsonConvert.DeserializeObject<FluentResult>(respons);
                resultList = Convert(fluentResult);

            }
            catch (Exception ex)
            {
                resultList.WithError(ex.Message);
            }

            return resultList;
        }

        //---------------------------------------
        //---------------------------------------
        private static FluentResults.Result<T> Convert<T>( FluentResult<T> input)
        {
            FluentResults.Result<T> result = new FluentResults.Result<T>();

            if (input.IsFailed)
            {
                foreach (var item in input.Errors)
                {
                    result.WithError(item.Message);
                }
            }

            if (input.IsSuccess)
            {
                foreach (var item in input.Successes)
                {
                    result.WithSuccess(item.Message);
                }
            }

            result.WithValue(input.Value);


            return result;
        }

        private static FluentResults.Result Convert(FluentResult input)
        {
            FluentResults.Result result = new FluentResults.Result();

            if (input.IsFailed)
            {
                foreach (var item in input.Errors)
                {
                    result.WithError(item.Message);
                }
            }

            if (input.IsSuccess)
            {
                foreach (var item in input.Successes)
                {
                    result.WithSuccess(item.Message);
                }
            }


            return result;
        }

        private static FluentResults.Result<T> Convert<T>( FluentResult input)
        {
            FluentResults.Result<T> result = new FluentResults.Result<T>();

            if (input.IsFailed)
            {
                foreach (var item in input.Errors)
                {
                    result.WithError(item.Message);
                }
            }

            if (input.IsSuccess)
            {
                foreach (var item in input.Successes)
                {
                    result.WithSuccess(item.Message);
                }
            }

            //result.WithValue(default(T));


            return result;
        }

    }
}
