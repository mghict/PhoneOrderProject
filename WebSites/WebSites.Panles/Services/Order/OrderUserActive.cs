using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Order
{
    public interface IOrderUserActive
    {
        Task<FluentResult<long>> Create(Models.Order.CustomerPreOrderUserActive model);
        Task<FluentResult<bool>> Delete(Models.Order.CustomerPreOrderUserActive model);
        Task<FluentResult<bool>> Update(Models.Order.CustomerPreOrderUserActive model);
        Task<Models.Order.CustomerPreOrderUserActive> GetByIdAsync(long id);
        Task<List<Models.Order.CustomerPreOrderUserActive>> GetDetailsByUserId(int userId);
        Task<List<Models.Order.CustomerPreOrderUserActiveSummery>> GetSummeryByUserId(int userId);
    }

    public class OrderUserActive : Base.ServiceBase,IOrderUserActive
    {
        public OrderUserActive(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public async Task<FluentResult<long>> Create(Models.Order.CustomerPreOrderUserActive model)
        {
            FluentResult<long> result = new FluentResult<long>();
            result.IsFailed = true;

            
            try
            {
                result = await ServiceCaller.PostDataWithValue<long>("Order/UserActive/Create", model);
                if(result.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.UserActivity);
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }

        public async Task<FluentResult<bool>> Delete(Models.Order.CustomerPreOrderUserActive model)
        {
            FluentResult<bool> result = new FluentResult<bool>();
            result.IsFailed = true;


            try
            {
                result = await ServiceCaller.PostDataWithValue<bool>("Order/UserActive/Delete", model);
                if (result.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.UserActivity);
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }

        public async Task<FluentResult<bool>> Update(Models.Order.CustomerPreOrderUserActive model)
        {
            FluentResult<bool> result = new FluentResult<bool>();
            result.IsFailed = true;


            try
            {
                result = await ServiceCaller.PostDataWithValue<bool>("Order/UserActive/Update", model);
                if (result.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.UserActivity);
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }

        private async Task<FluentResult<Models.Order.CustomerPreOrderUserActive>> getById(long id)
        {
            FluentResult<Models.Order.CustomerPreOrderUserActive> result = 
                new FluentResult<Models.Order.CustomerPreOrderUserActive>();

            result.IsFailed = true;

            var command = new
            {
                Id = id
            };

            try
            {
                result = await ServiceCaller.PostDataWithValue<Models.Order.CustomerPreOrderUserActive>("Order/UserActive/GetById", command);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }
        public async Task<Models.Order.CustomerPreOrderUserActive> GetByIdAsync(long id)
        {
            string key = $"UserActive-GetById-{id}";

            Models.Order.CustomerPreOrderUserActive ret =
                new Models.Order.CustomerPreOrderUserActive();

            ret = await CacheService.GetAsync<Models.Order.CustomerPreOrderUserActive>(key);

            if (ret == null)
            {
                var resp = await getById(id);
                if(resp!=null && resp.IsSuccess)
                {
                    ret = resp.Value;

                    await CacheService.RemoveAndSetAsync(
                            ret,
                            key,
                            TimeSpan.FromMinutes(10),
                            TimeSpan.FromMinutes(5),
                            Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                            TokenCachClass.UserActivity);
                }
                
            }

            return ret;
        }

        private async Task<FluentResult<List<Models.Order.CustomerPreOrderUserActive>>> getDetailsByUserId(int userId)
        {
            FluentResult<List<Models.Order.CustomerPreOrderUserActive>> result =
                new FluentResult<List<Models.Order.CustomerPreOrderUserActive>>();

            result.IsFailed = true;

            var command = new
            {
                UserId = userId
            };

            try
            {
                result = await ServiceCaller.PostDataWithValue<List<Models.Order.CustomerPreOrderUserActive>>("Order/UserActive/GetDetailsByUserId", command);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }
        public async Task<List<Models.Order.CustomerPreOrderUserActive>> GetDetailsByUserId(int userId)
        {
            string key = $"UserActive-GetDetailsByUserId-{userId}";

            List<Models.Order.CustomerPreOrderUserActive> ret =
                new List<Models.Order.CustomerPreOrderUserActive>();

            ret = await CacheService.GetAsync<List<Models.Order.CustomerPreOrderUserActive>>(key);

            if (ret == null)
            {
                var resp = await getDetailsByUserId(userId);

                if (resp != null && resp.IsSuccess && resp.Value.Count>0)
                {
                    ret = resp.Value;

                    await CacheService.RemoveAndSetAsync(
                            ret,
                            key,
                            TimeSpan.FromMinutes(10),
                            TimeSpan.FromMinutes(5),
                            Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                            TokenCachClass.UserActivity);
                }

            }

            return ret;
        }

        private async Task<FluentResult<List<Models.Order.CustomerPreOrderUserActiveSummery>>> getSummeryByUserId(int userId)
        {
            FluentResult<List<Models.Order.CustomerPreOrderUserActiveSummery>> result =
                new FluentResult<List<Models.Order.CustomerPreOrderUserActiveSummery>>();

            result.IsFailed = true;

            var command = new
            {
                UserId = userId
            };

            try
            {
                result = await ServiceCaller.PostDataWithValue<List<Models.Order.CustomerPreOrderUserActiveSummery>>("Order/UserActive/GetSummeryByUserId", command);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }
        public async Task<List<Models.Order.CustomerPreOrderUserActiveSummery>> GetSummeryByUserId(int userId)
        {
            string key = $"UserActive-GetSummeryByUserId-{userId}";

            List<Models.Order.CustomerPreOrderUserActiveSummery> ret =
                new List<Models.Order.CustomerPreOrderUserActiveSummery>();

            ret = await CacheService.GetAsync<List<Models.Order.CustomerPreOrderUserActiveSummery>>(key);

            if (ret == null)
            {
                var resp = await getSummeryByUserId(userId);

                if (resp != null && resp.IsSuccess && resp.Value.Count > 0)
                {
                    ret = resp.Value;

                    await CacheService.RemoveAndSetAsync(
                            ret,
                            key,
                            TimeSpan.FromMinutes(10),
                            TimeSpan.FromMinutes(5),
                            Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                            TokenCachClass.UserActivity);
                }

            }

            return ret;
        }
    }

}
