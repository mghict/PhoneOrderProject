using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Authorize
{
    public interface IUserActivityService 
    {

        //---------------------------------------------
        //---------------------------------------------
        Task<FluentResult<int>> CreateAsync(Models.Authorize.UserActivityModel model);

        Task<FluentResult<bool>> UpdateAsync(Models.Authorize.UserActivityModel model);

        Task<FluentResult<bool>> UpdateStatusAsync(Models.Authorize.UserActivityModel model);


        //---------------------------------------------
        //---------------------------------------------
        Task<Models.Authorize.UserActivityModel> GetByUserIdCurrentDateAsync(int userId);

        //---------------------------------------------
        //---------------------------------------------
        Task<Models.Authorize.UserModel> GetAllUserActiveCurrentDateAsync(int applicationId, float storeId = 0, string searchKey = "", int pageNumber = 0, int pageSize = 20, int status = 100);
        
    }

    public class UserActivityService : Base.ServiceBase, IUserActivityService
    {
        public UserActivityService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        //---------------------------------------------
        //---------------------------------------------
        public async Task<FluentResult<int>> CreateAsync(Models.Authorize.UserActivityModel model)
        {
            FluentResult<int> ret = new FluentResult<int>();

            try
            {
                ret = await ServiceCaller.PostDataWithValue<int>("Users/UserActive/Create", model);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.UserActivity);
                }
            }
            catch (Exception ex)
            {
                ret = new FluentResult<int>();
                ret.WithSuccess(ex.Message);
            }

            return ret;
        }
        public async Task<FluentResult<bool>> UpdateAsync(Models.Authorize.UserActivityModel model)
        {
            FluentResult<bool> ret = new FluentResult<bool>();

            try
            {
                ret = await ServiceCaller.PostDataWithValue<bool>("Users/UserActive/Update", model);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.UserActivity);
                }
            }
            catch (Exception ex)
            {
                ret = new FluentResult<bool>();
                ret.WithSuccess(ex.Message);
            }

            return ret;
        }
        public async Task<FluentResult<bool>> UpdateStatusAsync(Models.Authorize.UserActivityModel model)
        {
            FluentResult<bool> ret = new FluentResult<bool>();

            try
            {
                ret = await ServiceCaller.PostDataWithValue<bool>("Users/UserActive/UpdateStatus", model);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.UserActivity);
                }
            }
            catch (Exception ex)
            {
                ret = new FluentResult<bool>();
                ret.WithSuccess(ex.Message);
            }

            return ret;
        }

        //---------------------------------------------
        //---------------------------------------------
        private async Task<Models.Authorize.UserActivityModel> getByUserIdCurrentDateAsync(int userId)
        {
           Models.Authorize.UserActivityModel ret = new Models.Authorize.UserActivityModel();

            var command = new
            {
                UserId = userId
            };

            try
            {
                var resp = await ServiceCaller.PostDataWithValue<Models.Authorize.UserActivityModel>("Users/UserActive/GetByUserIdCurrentDate", command);
                if (resp != null && resp.IsSuccess)
                {
                    ret= resp.Value;
                }
            }
            catch (Exception ex)
            {
                ret = new Models.Authorize.UserActivityModel();
            }

            return ret;
        }
        public async Task<Models.Authorize.UserActivityModel> GetByUserIdCurrentDateAsync(int userId)
        {
            string key = $"GetByUserIdCurrentDateAsync-{userId}";

            Models.Authorize.UserActivityModel ret =
                new Models.Authorize.UserActivityModel();

            ret = await CacheService.GetAsync<Models.Authorize.UserActivityModel>(key);

            if (ret == null)
            {
                ret = await getByUserIdCurrentDateAsync(userId);
                await CacheService.RemoveAndSetAsync(
                        ret,
                        key,
                        TimeSpan.FromMinutes(20),
                        TimeSpan.FromMinutes(15),
                        Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                        TokenCachClass.UserActivity);
            }

            return ret;
        }

        //---------------------------------------------
        //---------------------------------------------
        private async Task<Models.Authorize.UserModel> getAllUserActiveCurrentDateAsync(int applicationId,float storeId=0,string searchKey="",int pageNumber=0,int pageSize=20,int status=100)
        {
            Models.Authorize.UserModel ret = new Models.Authorize.UserModel();

            var command = new
            {
                ApplicationId=applicationId,
                StoreId=storeId,
                SearchKey=searchKey,
                PageNumber=pageNumber,
                PageSize=pageSize,
                Status=status
            };

            try
            {
                var resp = await ServiceCaller.PostDataWithValue<Models.Authorize.UserModel>("Users/UserActive/GetAllUserActiveCurrentDate", command);
                if (resp != null && resp.IsSuccess)
                {
                    ret = resp.Value;
                }
            }
            catch (Exception ex)
            {
                ret = new Models.Authorize.UserModel();
            }

            return ret;
        }
        public async Task<Models.Authorize.UserModel> GetAllUserActiveCurrentDateAsync(int applicationId, float storeId = 0, string searchKey = "", int pageNumber = 0, int pageSize = 20, int status = 100)
        {
            string key = $"GetAllUserActiveCurrentDateAsync-{applicationId}-{storeId}-{searchKey}-{pageNumber}-{pageSize}-{status}";

            Models.Authorize.UserModel ret =
                new Models.Authorize.UserModel();

            ret = await CacheService.GetAsync<Models.Authorize.UserModel>(key);

            if (ret == null)
            {
                ret = await getAllUserActiveCurrentDateAsync(applicationId,storeId,searchKey,pageNumber,pageSize,status);
                await CacheService.RemoveAndSetAsync(
                        ret,
                        key,
                        TimeSpan.FromMinutes(20),
                        TimeSpan.FromMinutes(15),
                        Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                        TokenCachClass.UserActivity);
            }

            return ret;
        }
    }
}
