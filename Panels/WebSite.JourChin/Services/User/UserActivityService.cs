using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSite.JourChin.Helper;
using WebSite.JourChin.Models.User;

namespace WebSite.JourChin.Services.User
{
    public interface IUserActivityService 
    {

        //---------------------------------------------
        //---------------------------------------------
        Task<FluentResults.Result<int>> CreateAsync(Models.User.UserActivityModel model);

        Task<FluentResults.Result<bool>> UpdateAsync(Models.User.UserActivityModel model);

        Task<FluentResults.Result<bool>> UpdateStatusAsync(Models.User.UserActivityModel model);


        //---------------------------------------------
        //---------------------------------------------
        Task<Models.User.UserActivityModel> GetByUserIdCurrentDateAsync(int userId);

        //---------------------------------------------
        //---------------------------------------------
        Task<Models.User.UserModel> GetAllUserActiveCurrentDateAsync(int applicationId, float storeId = 0, string searchKey = "", int pageNumber = 0, int pageSize = 20, int status = 100);

        //---------------------------------------------
        //---------------------------------------------

        Task<List<Models.User.OrderUserActivity>> GetOrderUserActivityByStatusAsync(int userId, int status);
        Task<List<Models.User.OrderUserActivity>> GetOrderUserActivityByStatusItemsAsync(int userId, int status,int itemStatus);
    }

    public class UserActivityService : Base.ServiceBase, IUserActivityService
    {
        public UserActivityService(ICachedMemoryService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        //---------------------------------------------
        //---------------------------------------------
        public async Task<FluentResults.Result<int>> CreateAsync(Models.User.UserActivityModel model)
        {
            FluentResults.Result<int> ret = new FluentResults.Result<int>();

            try
            {
                ret = await ServiceCaller.PostDataWithValue<int>("Users/UserActive/Create", model);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.UserActivity);
                }
                else if (ret != null && ret.IsFailed)
                {
                    ret.WithValue(-1);
                }
            }
            catch (Exception ex)
            {
                ret = new FluentResults.Result<int>();
                ret.WithValue(-1);
                ret.WithError(ex.Message);
            }

            return ret;
        }
        public async Task<FluentResults.Result<bool>> UpdateAsync(Models.User.UserActivityModel model)
        {
            FluentResults.Result<bool> ret = new FluentResults.Result<bool>();

            try
            {
                ret = await ServiceCaller.PostDataWithValue<bool>("Users/UserActive/Update", model);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.UserActivity);
                }
                else if (ret != null && ret.IsFailed)
                {
                    ret.WithValue(false);
                }
            }
            catch (Exception ex)
            {
                ret = new FluentResults.Result<bool>();
                ret.WithValue(false);
                ret.WithError(ex.Message);
            }

            return ret;
        }
        public async Task<FluentResults.Result<bool>> UpdateStatusAsync(Models.User.UserActivityModel model)
        {
            FluentResults.Result<bool> ret = new FluentResults.Result<bool>();

            try
            {
                ret = await ServiceCaller.PostDataWithValue<bool>("Users/UserActive/UpdateStatus", model);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.UserActivity);
                }
                else if (ret != null && ret.IsFailed)
                {
                    ret.WithValue(false);
                }
            }
            catch (Exception ex)
            {
                ret = new FluentResults.Result<bool>();
                ret.WithValue(false);
                ret.WithError(ex.Message);
            }

            return ret;
        }

        //---------------------------------------------
        //---------------------------------------------
        private async Task<Models.User.UserActivityModel> getByUserIdCurrentDateAsync(int userId)
        {
           Models.User.UserActivityModel ret = new Models.User.UserActivityModel();

            var command = new
            {
                UserId = userId
            };

            try
            {
                var resp = await ServiceCaller.PostDataWithValue<Models.User.UserActivityModel>("Users/UserActive/GetByUserIdCurrentDate", command);
                if (resp != null && resp.IsSuccess)
                {
                    ret= resp.Value;
                }
            }
            catch (Exception ex)
            {
                ret = new Models.User.UserActivityModel();
            }

            return ret;
        }
        public async Task<Models.User.UserActivityModel> GetByUserIdCurrentDateAsync(int userId)
        {
            string key = $"GetByUserIdCurrentDateAsync-{userId}";

            Models.User.UserActivityModel ret =
                new Models.User.UserActivityModel();

            ret = await CacheService.GetCachedAsync<Models.User.UserActivityModel>(key);

            if (ret == null)
            {
                ret = await getByUserIdCurrentDateAsync(userId);
                await CacheService.SetCachedAsync(
                        ret,
                        TimeSpan.FromMinutes(20),
                        TimeSpan.FromMinutes(15),
                        Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                        TokenCachClass.UserActivity,
                        key);
            }

            return ret;
        }

        //---------------------------------------------
        //---------------------------------------------
        private async Task<Models.User.UserModel> getAllUserActiveCurrentDateAsync(int applicationId,float storeId=0,string searchKey="",int pageNumber=0,int pageSize=20,int status=100)
        {
            Models.User.UserModel ret = new Models.User.UserModel();

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
                var resp = await ServiceCaller.PostDataWithValue<Models.User.UserModel>("Users/UserActive/GetAllUserActiveCurrentDate", command);
                if (resp != null && resp.IsSuccess)
                {
                    ret = resp.Value;
                }
            }
            catch (Exception ex)
            {
                ret = new Models.User.UserModel();
            }

            return ret;
        }
        public async Task<Models.User.UserModel> GetAllUserActiveCurrentDateAsync(int applicationId, float storeId = 0, string searchKey = "", int pageNumber = 0, int pageSize = 20, int status = 100)
        {
            string key = $"GetAllUserActiveCurrentDateAsync-{applicationId}-{storeId}-{searchKey}-{pageNumber}-{pageSize}-{status}";

            Models.User.UserModel ret =
                new Models.User.UserModel();

            ret = await CacheService.GetCachedAsync<Models.User.UserModel>(key);

            if (ret == null)
            {
                ret = await getAllUserActiveCurrentDateAsync(applicationId,storeId,searchKey,pageNumber,pageSize,status);
                await CacheService.SetCachedAsync(
                        ret,
                        TimeSpan.FromMinutes(20),
                        TimeSpan.FromMinutes(15),
                        Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                        TokenCachClass.UserActivity,
                        key);
            }

            return ret;
        }

        //---------------------------------------------
        //---------------------------------------------

        public async Task<List<Models.User.OrderUserActivity>> GetOrderUserActivityByStatusAsync(int userId,int status)
        {
            List<Models.User.OrderUserActivity> ret = new List<Models.User.OrderUserActivity>();

            var command = new
            {
                UserId=userId,
                Status = status
            };

            try
            {
                var resp = await ServiceCaller.PostDataWithValue<List<Models.User.OrderUserActivity>>("Order/UserActive/GetOrderUserActivityByStatus", command);
                if (resp != null && resp.IsSuccess)
                {
                    ret = resp.Value;
                }
            }
            catch (Exception ex)
            {
                ret = new List<Models.User.OrderUserActivity>();
            }

            return ret;
        }
        public async Task<List<OrderUserActivity>> GetOrderUserActivityByStatusItemsAsync(int userId, int status, int itemStatus)
        {
            List<Models.User.OrderUserActivity> ret = new List<Models.User.OrderUserActivity>();

            var command = new
            {
                UserId = userId,
                Status = status,
                ItemStatus=itemStatus
            };

            try
            {
                var resp = await ServiceCaller.PostDataWithValue<List<Models.User.OrderUserActivity>>("Order/UserActive/GetOrderUserActivityByStatusItems", command);
                if (resp != null && resp.IsSuccess)
                {
                    ret = resp.Value;
                }
            }
            catch (Exception ex)
            {
                ret = new List<Models.User.OrderUserActivity>();
            }

            return ret;
        }
    }
}
