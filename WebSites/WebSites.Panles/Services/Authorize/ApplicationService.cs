using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Authorize
{
    public interface IApplicationService
    {
        Task<List<Models.Authorize.ApplicationInfoModel>> GetAll();
        Task<FluentResult> Update(Models.Authorize.ApplicationInfoModel model);
        Task<Models.Authorize.ApplicationInfoModel> GetById(int id);
    }

    public class ApplicationService : Base.ServiceBase, IApplicationService
    {
        public ApplicationService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        private async Task<List<Models.Authorize.ApplicationInfoModel>> getAll()
        {
            try
            {
                var result = await ServiceCaller.GetDataWithValue<List<Models.Authorize.ApplicationInfoModel>>("Users/Application/GetAll");
                if(result!=null && result.IsSuccess)
                {
                    return result.Value;
                }

                return new List<Models.Authorize.ApplicationInfoModel>();
            }
            catch
            {
                return new List<Models.Authorize.ApplicationInfoModel>();
            }
        }

        public async Task<List<Models.Authorize.ApplicationInfoModel>> GetAll()
        {
            string key = $"ApplicationInfo";
            var ret = await CacheService.GetAsync<List<Models.Authorize.ApplicationInfoModel>>(key);
            if(ret==null || ret.Count<=0)
            {
                ret = await getAll();

                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(10),
                    TimeSpan.FromMinutes(5),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal
                    ) ;
            }

            return ret;
        }

        public async Task<Models.Authorize.ApplicationInfoModel> GetById(int id)
        {
            string key = $"ApplicationInfo";
            var ret = await CacheService.GetAsync<List<Models.Authorize.ApplicationInfoModel>>(key);
            if (ret == null || ret.Count <= 0)
            {
                ret = await getAll();

                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(10),
                    TimeSpan.FromMinutes(5),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal
                    );
            }

            return ret.FirstOrDefault(p=>p.Id==id);
        }

        public async Task<FluentResult> Update(Models.Authorize.ApplicationInfoModel model)
        {
            var result = new FluentResult();
            try
            {
                result = await ServiceCaller.PostDataWithoutValue("Users/Application/Update",model);
                if(result.IsSuccess)
                {
                    string key = $"ApplicationInfo";
                    await CacheService.ClearCacheAsync(key);
                }
                return result;

            }
            catch(Exception ex)
            {
                return result.WithError(ex.Message);
            }
        }
    }

}
