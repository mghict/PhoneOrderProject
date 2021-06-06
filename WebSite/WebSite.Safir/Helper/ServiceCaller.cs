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
using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace WebSite.Safir.Helper
{

    public class ServiceCaller
    {
        private string Token { get; set; }
        private HttpClient client { get; set; }
        private UserLoginData _userData { get;}
        private Settings settings { get; set; }

        public ServiceCaller(HttpClient HttpClient,Settings Settings, UserLoginData UserData)
        {
            client = HttpClient;
            settings = Settings;
            _userData = UserData;

            
            client.BaseAddress =new Uri(settings.ApiGatewayURL);

            if (_userData != null && _userData.UserData != null)
            {
                SetToken(_userData.UserData.Token);
            }

            client.Timeout = TimeSpan.FromMinutes(2);

        }

        private void InitialClient()
        {

            client.DefaultRequestHeaders.Clear();

            client.DefaultRequestHeaders.Add("Access-Control-Allow-Methods", "*");

            client.DefaultRequestHeaders.Add("Acces-Control-Allow-Methods", "GET, POST, PATCH, DELETE");

            client.DefaultRequestHeaders.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type,Accept, Authortization");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "no-cors");
            client.DefaultRequestHeaders.Add("Mode", "no-cors");

            if (!string.IsNullOrEmpty(Token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Token);
            }

            try
            {
                var user = _userData.UserData?? new Models.LoginUserModel();
                if (user != null && user.UserId>0)
                {

                    var userName = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(user.PhoneNumber));


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
