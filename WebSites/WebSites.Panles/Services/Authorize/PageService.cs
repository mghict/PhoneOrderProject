using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Authorize
{
    public interface IPageService
    {
        Task<List<Models.Authorize.PageInfoModel>> GetAll();
        Task<List<Models.Authorize.PageInfoModel>> GetByApplicationId(int appId);
        Task<List<Models.Authorize.PageInfoModel>> GetByApplicationIdParents(int appId);
        Task<List<Models.Authorize.PageInfoModel>> GetByParentId(int parentId);
        Task<Models.Authorize.PageInfoModel> GetById(int id);
        Task<FluentResult> Create(Models.Authorize.PageInfoModel model);
        Task<FluentResult> Update(Models.Authorize.PageInfoModel model);
        Task<FluentResult> Delete(int id);
    }

    public class PageService : Base.ServiceBase,IPageService
    {
        public PageService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        private async Task<List<Models.Authorize.PageInfoModel>> getAll()
        {
            List<Models.Authorize.PageInfoModel> ret =
                new List<Models.Authorize.PageInfoModel>();

            try
            {
                var resp = await ServiceCaller.GetDataWithValue<List<Models.Authorize.PageInfoModel>>("Users/Page/GetAll");
                if(resp!=null && resp.IsSuccess && resp.Value!=null && resp.Value.Count>0)
                {
                    ret = resp.Value;
                }    
            }
            catch(Exception ex)
            {
                ret = new List<Models.Authorize.PageInfoModel>();
            }

            return ret;
        }

        private async Task<Models.Authorize.PageInfoModel> getById(int id)
        {
            Models.Authorize.PageInfoModel ret =
                new Models.Authorize.PageInfoModel();

            var command = new
            {
                Id=id
            };

            try
            {
                var resp = await ServiceCaller.PostDataWithValue<Models.Authorize.PageInfoModel>("Users/Page/GetById",command);
                if (resp != null && resp.IsSuccess && resp.Value != null)
                {
                    ret = resp.Value;
                }
            }
            catch (Exception ex)
            {
                ret = new Models.Authorize.PageInfoModel();
            }

            return ret;
        }

        private async Task<List<Models.Authorize.PageInfoModel>> getByApplicationId(int appId)
        {
            List<Models.Authorize.PageInfoModel> ret =
                new List<Models.Authorize.PageInfoModel>();

            var command = new
            {
                ApplicationId=appId
            };

            try
            {
                var resp = await ServiceCaller.PostDataWithValue<List<Models.Authorize.PageInfoModel>>("Users/Page/GetByApplicationId", command);
                if (resp != null && resp.IsSuccess && resp.Value != null && resp.Value.Count>0)
                {
                    ret = resp.Value;
                }
            }
            catch (Exception ex)
            {
                ret = new List<Models.Authorize.PageInfoModel>();
            }

            return ret;
        }

        private async Task<List<Models.Authorize.PageInfoModel>> getByApplicationIdParents(int appId)
        {
            List<Models.Authorize.PageInfoModel> ret =
                new List<Models.Authorize.PageInfoModel>();

            var command = new
            {
                ApplicationId = appId
            };

            try
            {
                var resp = await ServiceCaller.PostDataWithValue<List<Models.Authorize.PageInfoModel>>("Users/Page/GetByApplicationIdParents", command);
                if (resp != null && resp.IsSuccess && resp.Value != null && resp.Value.Count > 0)
                {
                    ret = resp.Value;
                }
            }
            catch (Exception ex)
            {
                ret = new List<Models.Authorize.PageInfoModel>();
            }

            return ret;
        }

        private async Task<List<Models.Authorize.PageInfoModel>> getByParentId(int parentId)
        {
            List<Models.Authorize.PageInfoModel> ret =
                new List<Models.Authorize.PageInfoModel>();

            var command = new
            {
                ParentId = parentId
            };

            try
            {
                var resp = await ServiceCaller.PostDataWithValue<List<Models.Authorize.PageInfoModel>>("Users/Page/GetByParentId", command);
                if (resp != null && resp.IsSuccess && resp.Value != null && resp.Value.Count > 0)
                {
                    ret = resp.Value;
                }
            }
            catch (Exception ex)
            {
                ret = new List<Models.Authorize.PageInfoModel>();
            }

            return ret;
        }

        public async Task<List<Models.Authorize.PageInfoModel>> GetAll()
        {
            string key = $"PageInfoAll";
            List<Models.Authorize.PageInfoModel> ret =
                new List<Models.Authorize.PageInfoModel>();

            ret = await CacheService.GetAsync<List<Models.Authorize.PageInfoModel>>(key);
            if(ret==null || ret.Count==0)
            {
                ret = await getAll();
                await CacheService.RemoveAndSetAsync(
                        ret,
                        key,
                        TimeSpan.FromMinutes(12),
                        TimeSpan.FromMinutes(10),
                        Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                        TokenCachClass.Page);
            }

            return ret;
        }

        public async Task<List<Models.Authorize.PageInfoModel>> GetByApplicationId(int appId)
        {
            string key = $"PageInfo-ApplicationId-{appId}";

            List<Models.Authorize.PageInfoModel> ret =
                new List<Models.Authorize.PageInfoModel>();

            ret = await CacheService.GetAsync<List<Models.Authorize.PageInfoModel>>(key);

            if (ret == null || ret.Count == 0)
            {
                ret = await getByApplicationId(appId);
                await CacheService.RemoveAndSetAsync(
                        ret,
                        key,
                        TimeSpan.FromMinutes(12),
                        TimeSpan.FromMinutes(10),
                        Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                        TokenCachClass.Page);
            }

            return ret;
        }

        public async Task<List<Models.Authorize.PageInfoModel>> GetByApplicationIdParents(int appId)
        {
            string key = $"PageInfo-ApplicationIdParents-{appId}";

            List<Models.Authorize.PageInfoModel> ret =
                new List<Models.Authorize.PageInfoModel>();

            ret = await CacheService.GetAsync<List<Models.Authorize.PageInfoModel>>(key);

            if (ret == null || ret.Count == 0)
            {
                ret = await getByApplicationIdParents(appId);
                await CacheService.RemoveAndSetAsync(
                        ret,
                        key,
                        TimeSpan.FromMinutes(12),
                        TimeSpan.FromMinutes(10),
                        Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                        TokenCachClass.Page);
            }

            return ret;
        }

        public async Task<List<Models.Authorize.PageInfoModel>> GetByParentId(int parentId)
        {
            string key = $"PageInfo-ParentId-{parentId}";

            List<Models.Authorize.PageInfoModel> ret =
                new List<Models.Authorize.PageInfoModel>();

            ret = await CacheService.GetAsync<List<Models.Authorize.PageInfoModel>>(key);

            if (ret == null || ret.Count == 0)
            {
                ret = await getByParentId(parentId);
                await CacheService.RemoveAndSetAsync(
                        ret,
                        key,
                        TimeSpan.FromMinutes(12),
                        TimeSpan.FromMinutes(10),
                        Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                        TokenCachClass.Page);
            }

            return ret;
        }

        public async Task<Models.Authorize.PageInfoModel> GetById(int id)
        {
            string key = $"PageInfo-ById-{id}";

            Models.Authorize.PageInfoModel ret =
                new Models.Authorize.PageInfoModel();

            ret = await CacheService.GetAsync<Models.Authorize.PageInfoModel>(key);

            if (ret == null )
            {
                ret = await getById(id);
                await CacheService.RemoveAndSetAsync(
                        ret,
                        key,
                        TimeSpan.FromMinutes(10),
                        TimeSpan.FromMinutes(2),
                        Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                        TokenCachClass.Page);
            }

            return ret;
        }

        public async Task<FluentResult> Create(Models.Authorize.PageInfoModel model)
        {
            FluentResult ret =
                new FluentResult();
            
            var command = new
            {
                PageName = model.PageName,
                DisplayName = model.DisplayName,
                ApplicationId = model.ApplicationId,
                ParentId = model.ParentId,
                Status = model.Status
            };

            try
            {
                ret = await ServiceCaller.PostDataWithoutValue("Users/Page/Create", command);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.Page);
                }
            }
            catch (Exception ex)
            {
                ret = new FluentResult();
            }

            return ret;
        }

        public async Task<FluentResult> Update(Models.Authorize.PageInfoModel model)
        {
            FluentResult ret =
                new FluentResult();
            
            var command = new
            {
                Id=model.Id,
                PageName = model.PageName,
                DisplayName = model.DisplayName,
                ApplicationId = model.ApplicationId,
                ParentId = model.ParentId,
                Status = model.Status
            };

            try
            {
                ret = await ServiceCaller.PostDataWithoutValue("Users/Page/Update", command);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.Page);
                }
            }
            catch (Exception ex)
            {
                ret = new FluentResult();
            }

            return ret;
        }

        public async Task<FluentResult> Delete(int id)
        {
            FluentResult ret =
                new FluentResult();

            var model = new
            {
                Id = id
            };

            try
            {
                ret = await ServiceCaller.PostDataWithoutValue("Users/Page/Delete", model);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.Page);
                }
            }
            catch (Exception ex)
            {
                ret = new FluentResult();
            }

            return ret;
        }
    }
}
