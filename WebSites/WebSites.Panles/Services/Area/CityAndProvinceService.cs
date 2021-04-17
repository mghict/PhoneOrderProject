using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Area
{
    public interface ICityAndProvinceService
    {
        Task<List<Models.Area.CityTbl>> GetAllCityAsync();
        Task<List<Models.Area.CityTbl>> GetAllCityByProvinceAsync(float provinceId);
        Task<List<Models.Area.ProvinceTbl>> GetAllProvinceAsync();
    }

    public class CityAndProvinceService : Base.ServiceBase, ICityAndProvinceService
    {
        public CityAndProvinceService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        private async Task<List<Models.Area.CityTbl>> getAllCity()
        {
            try
            {
                var ret = await ServiceCaller.GetDataWithValue<List<Models.Area.CityTbl>>("Setting/Area/GetAllCity");
                if (ret != null && ret.IsSuccess)
                {
                    return ret.Value;
                }
                else
                {
                    return new List<Models.Area.CityTbl>();
                }
            }
            catch (Exception ex)
            {
                return new List<Models.Area.CityTbl>();
            }
        }
        private async Task<List<Models.Area.CityTbl>> getAllCityByProvince(float provinceId)
        {
            var command = new
            {
                ProvinceId = provinceId
            };
            try
            {
                var ret = await ServiceCaller.PostDataWithValue<List<Models.Area.CityTbl>>("Setting/Area/GetAllCityByProvince", command);
                if (ret != null && ret.IsSuccess && ret.Value!=null )
                {
                    return ret.Value;
                }
                else
                {
                    return new List<Models.Area.CityTbl>();
                }
            }
            catch (Exception ex)
            {
                return new List<Models.Area.CityTbl>();
            }
        }
        private async Task<List<Models.Area.ProvinceTbl>> getAllProvince()
        {
            try
            {
                var ret = await ServiceCaller.GetDataWithValue<List<Models.Area.ProvinceTbl>>("Setting/Area/GetAllProvince");
                if (ret != null && ret.IsSuccess)
                {
                    return ret.Value;
                }
                else
                {
                    return new List<Models.Area.ProvinceTbl>();
                }
            }
            catch (Exception ex)
            {
                return new List<Models.Area.ProvinceTbl>();
            }
        }

        public async Task<List<Models.Area.CityTbl>> GetAllCityAsync()
        {
            string key = $"CityGetAll";
            var ret = await CacheService.GetAsync<List<Models.Area.CityTbl>>(key);
            if (ret == null)
            {
                ret = await getAllCity();
                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(15),
                    TimeSpan.FromMinutes(5),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.City
                    );
            }

            return ret;
        }
        public async Task<List<Models.Area.CityTbl>> GetAllCityByProvinceAsync(float provinceId)
        {
            string key = $"CityByProvince-{provinceId}";
            var ret = await CacheService.GetAsync<List<Models.Area.CityTbl>>(key);
            if (ret == null)
            {
                ret = await getAllCityByProvince(provinceId);
                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(15),
                    TimeSpan.FromMinutes(5),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.City
                    );
            }

            return ret;
        }
        public async Task<List<Models.Area.ProvinceTbl>> GetAllProvinceAsync()
        {
            string key = $"ProvinceGetAll";
            var ret = await CacheService.GetAsync<List<Models.Area.ProvinceTbl>>(key);
            if (ret == null)
            {
                ret = await getAllProvince();
                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(15),
                    TimeSpan.FromMinutes(5),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.Province
                    );
            }

            return ret;
        }
    }
}
