using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Map
{
    public class NeshanMapService 
    {
        private HttpClient client;
        private IConfiguration configuration;
        private string BaseUrl;
        private string ApiKey;
        public NeshanMapService(IHttpClientFactory _clientFactory, IConfiguration Configuration)
        {
            client = _clientFactory.CreateClient("ApiMap");
            configuration = Configuration;
            BaseUrl = Configuration.GetValue<string>("ApiMapURL");
            ApiKey = Configuration.GetValue<string>("ApiKey");
        }

        private void InitialClient()
        {

            client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Api-Key", ApiKey);
        }

        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------

        public async Task<Models.Map.GeocodingModel> GeocodingApi(string address)
        {
            string method = $"v4/geocoding?address={address}";
            var result =await CallerRestClientMethods<Models.Map.GeocodingModel>(method);
            return result;
        }

        public async Task<Models.Map.ReverseGeocodingModel> ReverseGeocodingApi(decimal lat,decimal lng)
        {
            var latStr = lat.ToString(CultureInfo.InvariantCulture);
            var lngStr = lng.ToString(CultureInfo.InvariantCulture);
            string method = $"v2/reverse?lat={latStr}&lng={lngStr}";
            var result = await CallerRestClientMethods<Models.Map.ReverseGeocodingModel>(method);
            return result;
        }

        public async Task<Models.Map.SearchAddressModel> SearchApi(string address,string lat,string lng)
        {
            string method = $"v1/search?term={address}&lat={lat}&lng={lng}";

            var result = await CallerRestClientMethods<Models.Map.SearchAddressModel>(method);

            return result;
        }

        //--------------------------------------------------------------------
        //--------------------------------------------------------------------
        private async Task<T> CallerClientMethods<T>(string mothodsName)
        {

            InitialClient();

          

            try
            {

                var result = await client.GetAsync(mothodsName);
                if (result.IsSuccessStatusCode)
                {
                    var resp = await result.Content.ReadAsAsync<T>();

                    return resp;
                }

                return default(T);
            }
            catch (Exception ex)
            {
                return default(T);
            }

        }

        private async Task<T> CallerRestClientMethods<T>(string mothodsName)
        {

            var _client = new RestClient(BaseUrl + mothodsName);
            _client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Api-Key", ApiKey);
            IRestResponse response = _client.Execute(request);

            var ret = JsonConvert.DeserializeObject<T>(response.Content);

           if(ret==null)
            {
                return default(T);
            }

            return ret;

        }
    }
}
