using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Authorize
{
    public interface IRoleService
    {
        Task<Models.Authorize.RoleInfoModel> GetById(int id);
        Task<List<Models.Authorize.RoleInfoModel>> GetByApplicationId(int appId);
        Task<FluentResult> CreateAsync(Models.Authorize.RoleInfoModel model);
        Task<FluentResult> UpdateAsync(Models.Authorize.RoleInfoModel model);
        Task<FluentResult> DeleteAsync(int id);
        Task<FluentResult> CreatePermisionsAsync(List<Models.Authorize.PermistionModel> input);
        Task<List<Models.Authorize.PermistionModel>> GetPermisionsAsync(int roleId);
    }

    public class RoleService : Base.ServiceBase,IRoleService
    {
        public RoleService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        private async Task<Models.Authorize.RoleInfoModel> getById(int id)
        {
            Models.Authorize.RoleInfoModel ret =
                new Models.Authorize.RoleInfoModel();
            var command = new
            {
                Id = id
            };

            try
            {
                var resp = await ServiceCaller.PostDataWithValue<Models.Authorize.RoleInfoModel>("Users/Role/GetById", command);
                if (resp != null && resp.IsSuccess && resp.Value!=null )
                {
                    ret = resp.Value;
                }
            }
            catch(Exception ex)
            {
                ret = new Models.Authorize.RoleInfoModel();
            }

            return ret;
        }

        private async Task<List<Models.Authorize.RoleInfoModel>> getByApplicationId(int appId)
        {
            List<Models.Authorize.RoleInfoModel> ret =
                new List<Models.Authorize.RoleInfoModel>();
            var command = new
            {
                ApplicationId = appId
            };

            try
            {
                var resp = await ServiceCaller.PostDataWithValue<List<Models.Authorize.RoleInfoModel>>("Users/Role/GetByApplicationId", command);
                if (resp != null && resp.IsSuccess && resp.Value != null && resp.Value.Count>0)
                {
                    ret = resp.Value;
                }
            }
            catch (Exception ex)
            {
                ret = new List<Models.Authorize.RoleInfoModel>();
            }

            return ret;
        }

        public async Task<Models.Authorize.RoleInfoModel> GetById(int id)
        {
            string key = $"RoleInfo-ById-{id}";

            Models.Authorize.RoleInfoModel ret =
                new Models.Authorize.RoleInfoModel();

            ret = await CacheService.GetAsync<Models.Authorize.RoleInfoModel>(key);

            if (ret == null)
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

        public async Task<List<Models.Authorize.RoleInfoModel>> GetByApplicationId(int appId)
        {
            string key = $"RoleInfo-ApplicationId-{appId}";

            List<Models.Authorize.RoleInfoModel> ret =
                new List<Models.Authorize.RoleInfoModel>();

            ret = await CacheService.GetAsync<List<Models.Authorize.RoleInfoModel>>(key);

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

        public async Task<FluentResult> CreateAsync(Models.Authorize.RoleInfoModel model)
        {
            FluentResult ret = new FluentResult();
            var command = new
            {
                RoleName=model.RoleName,
                ApplicationId=model.ApplicationId,
                Status=model.Status
            };

            try
            {
                ret = await ServiceCaller.PostDataWithoutValue("Users/Role/Create", command);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.Page);
                }
            }
            catch (Exception ex)
            {
                ret = new FluentResult();
                ret.WithSuccess(ex.Message);
            }

            return ret;
        }

        public async Task<FluentResult> UpdateAsync(Models.Authorize.RoleInfoModel model)
        {
            FluentResult ret = new FluentResult();
            var command = new
            {
                RoleName = model.RoleName,
                ApplicationId = model.ApplicationId,
                Status = model.Status,
                Id=model.Id
            };

            try
            {
                ret = await ServiceCaller.PostDataWithoutValue("Users/Role/Update", command);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.Page);
                }
            }
            catch (Exception ex)
            {
                ret = new FluentResult();
                ret.WithSuccess(ex.Message);
            }

            return ret;
        }

        public async Task<FluentResult> DeleteAsync(int id)
        {
            FluentResult ret = new FluentResult();
            var command = new
            {
                Id = id
            };

            try
            {
                ret = await ServiceCaller.PostDataWithoutValue("Users/Role/Delete", command);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.Page);
                }
            }
            catch (Exception ex)
            {
                ret = new FluentResult();
                ret.WithSuccess(ex.Message);
            }

            return ret;
        }

        public async Task<FluentResult> CreatePermisionsAsync(List<Models.Authorize.PermistionModel> input)
        {
            FluentResult ret = new FluentResult();
            var command = new
            {
                Permision = input
            };

            try
            {
                ret = await ServiceCaller.PostDataWithoutValue("Users/Role/CreatePermisions", command);
            }
            catch (Exception ex)
            {
                ret = new FluentResult();
                ret.WithSuccess(ex.Message);
            }

            return ret;
        }

        public async Task<List<Models.Authorize.PermistionModel>> GetPermisionsAsync(int roleId)
        {
            List<Models.Authorize.PermistionModel> ret = new List<Models.Authorize.PermistionModel>();
            var command = new
            {
                RoleId = roleId
            };

            try
            {
                var resp = await ServiceCaller.PostDataWithValue< List<Models.Authorize.PermistionModel>>("Users/Role/GetPermisions", command);
                ret = resp.Value;
            }
            catch (Exception ex)
            {
                ret = new List<Models.Authorize.PermistionModel> ();
            }

            return ret;
        }
    }
}
