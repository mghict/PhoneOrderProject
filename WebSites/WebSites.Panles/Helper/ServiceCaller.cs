﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace WebSites.Panles.Helper
{
    public interface IServiceCaller
    {
        void SetToken(string tokenValue);
        Task<FluentResults.Result<object>> GetData(string methodName);
        Task<FluentResults.Result<object>> PostData(string methodName, object input);
    }
    public class ServiceCaller<T> //: IServiceCaller<T>
    {
        private string Token { get; set; }
        private HttpClient client { get; set; }
        public ServiceCaller(IHttpClientFactory _clientFactory)
        {
            client = _clientFactory.CreateClient("ApiGateway");
        }

        private async Task InitialClient()
        {
            await Task.Run(() =>
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
                //        client.DefaultRequestHeaders.Add("Name", user.Name);
                //        client.DefaultRequestHeaders.Add("Id", user.UserId.ToString());
                //        client.DefaultRequestHeaders.Add("IP", user.UserIp);
                //    }
                //}
                //catch
                //{

                //}
            });

        }

        public void SetToken(string tokenValue)
        {
            if (string.IsNullOrEmpty(tokenValue))
                Token = tokenValue;
        }

        public async Task<FluentResult<T>> GetDataWithValue(string methodName)
        {
            FluentResult<T> resultList = new FluentResult<T>();

            await InitialClient();

            try
            {
                resultList = await client.GetFromJsonAsync<FluentResult<T>>(methodName);

                //var respons = await result.Content.ReadAsStringAsync();
                //var resulttmp = JsonConvert.DeserializeObject<FluentResult<T>>(respons);
                //return resulttmp;
            }
            catch (Exception ex)
            {
                resultList.WithError(ex.Message);
            }

            return resultList;
        }
        public async Task<T> GetDataWithValueAggregate(string methodName)
        {
            T resultList;

            await InitialClient();


            resultList = await client.GetFromJsonAsync<T>(methodName);


            return resultList;
        }
        public async Task<FluentResult<T>> PostDataWithValue(string methodName, object input)
        {
            FluentResult<T> resultList = new FluentResult<T>();

            await InitialClient();

            try
            {
                var result = await client.PostAsJsonAsync(methodName, input);
                //if(result.IsSuccessStatusCode)
                //{

                var respons = await result.Content.ReadAsStringAsync();
                var resulttmp = JsonConvert.DeserializeObject<FluentResult<T>>(respons);
                return resulttmp;
                //}
            }
            catch (Exception ex)
            {
                resultList.WithError(ex.Message);
                return resultList;
            }


        }
        public async Task<FluentResults.Result> PostDataWithoutValue(string methodName, object input)
        {
            FluentResults.Result resultList = new FluentResults.Result();

            await InitialClient();

            try
            {
                var result = await client.PostAsJsonAsync(methodName, input);
                //if(result.IsSuccessStatusCode)
                //{

                var respons = await result.Content.ReadAsStringAsync();
                resultList = JsonConvert.DeserializeObject<FluentResults.Result>(respons);
                //}
            }
            catch (Exception ex)
            {
                resultList.WithError(ex.Message);
            }

            return resultList;
        }
    }

    public class ServiceCaller
    {
        private string Token { get; set; }
        private HttpClient client { get; set; }
        private IHttpContextAccessor MyContext;

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

        public async Task<FluentResult<T>> GetDataWithValue<T>(string methodName)
        {
            FluentResult<T> resultList = new FluentResult<T>();

            InitialClient();

            try
            {

                var result = await client.GetAsync(methodName);
                if (result.IsSuccessStatusCode)
                {
                    resultList = await result.Content.ReadAsAsync<FluentResult<T>>();
                }
                else
                {
                    var resultListError = await result.Content.ReadAsAsync<FluentResult>();
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
                if (result.IsSuccessStatusCode)
                {
                    var respons = await result.Content.ReadAsStringAsync();
                    returnValue = JsonConvert.DeserializeObject<FluentResult<T>>(respons);
                }
                else
                {
                    var resultListError = await result.Content.ReadAsAsync<FluentResult>();
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
