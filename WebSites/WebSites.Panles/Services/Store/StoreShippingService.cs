using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Store
{
    public interface IStoreShippingService
    {
        Task<FluentResult> Create(Models.Store.StoreShippingTbl model);
        Task<FluentResult> CreateArea(Models.Store.StoreShippingAreaTbl model);
        Task<FluentResult> Update(Models.Store.StoreShippingTbl model);
        Task<FluentResult> UpdateArea(Models.Store.StoreShippingAreaTbl model);
        Task<FluentResult> DeleteArea(int id);
        Task<Models.Store.StoreShippingTbl> GetByIdAsync(int id);
        Task<Models.Store.StoreShippingAreaTbl> GetByIdAreaAsync(int id);
        Task<Models.Store.StoreShippingTbl> GetByStoreIdAsync(float storeId);
        Task<List<Models.Store.StoreShippingAreaTbl>> GetByStoreIdAreaAsync(float storeId);
        Task<List<Models.Store.StoreShippingTbl>> GetAllAsync();
        Task<List<Models.Store.StoreShippingAreaTbl>> GetAllAreaAsync();

    }
    public class StoreShippingService : Base.ServiceBase, IStoreShippingService
    {
        public StoreShippingService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        private async Task<List<Models.Store.StoreShippingTbl>> getAll()
        {
           
            try
            {
                var ret = await ServiceCaller.GetDataWithValue<List<Models.Store.StoreShippingTbl>>("Setting/StoreShipping/GetAll");
                if (ret != null && ret.IsSuccess)
                {
                    return ret.Value;
                }
                else
                {
                    return new List<Models.Store.StoreShippingTbl>();
                }
            }
            catch (Exception ex)
            {
                return new List<Models.Store.StoreShippingTbl>();
            }
        }
        private async Task<List<Models.Store.StoreShippingAreaTbl>> getAllArea()
        {

            try
            {
                var ret = await ServiceCaller.GetDataWithValue<List<Models.Store.StoreShippingAreaTbl>>("Setting/StoreShipping/GetAllArea");
                if (ret != null && ret.IsSuccess)
                {
                    return ret.Value;
                }
                else
                {
                    return new List<Models.Store.StoreShippingAreaTbl>();
                }
            }
            catch (Exception ex)
            {
                return new List<Models.Store.StoreShippingAreaTbl>();
            }
        }

        private async Task<Models.Store.StoreShippingTbl> getById(int id)
        {
            var command = new
            {
                Id=id
            };

            try
            {
                var ret = await ServiceCaller.PostDataWithValue<Models.Store.StoreShippingTbl>("Setting/StoreShipping/GetById", command);
                if (ret != null && ret.IsSuccess)
                {
                    return ret.Value;
                }
                else
                {
                    return new Models.Store.StoreShippingTbl();
                }
            }
            catch (Exception ex)
            {
                return new Models.Store.StoreShippingTbl();
            }
        }
        private async Task<Models.Store.StoreShippingAreaTbl> getByIdArea(int id)
        {
            var command = new
            {
                Id = id
            };

            try
            {
                var ret = await ServiceCaller.PostDataWithValue<Models.Store.StoreShippingAreaTbl>("Setting/StoreShipping/GetByIdArea", command);
                if (ret != null && ret.IsSuccess)
                {
                    return ret.Value;
                }
                else
                {
                    return new Models.Store.StoreShippingAreaTbl();
                }
            }
            catch (Exception ex)
            {
                return new Models.Store.StoreShippingAreaTbl();
            }
        }


        private async Task<Models.Store.StoreShippingTbl> getByStoreId(float storeId)
        {
            var command = new
            {
                StoreId = storeId
            };

            try
            {
                var ret = await ServiceCaller.PostDataWithValue<Models.Store.StoreShippingTbl>("Setting/StoreShipping/GetByStoreId", command);
                if (ret != null && ret.IsSuccess)
                {
                    return ret.Value;
                }
                else
                {
                    return new Models.Store.StoreShippingTbl();
                }
            }
            catch (Exception ex)
            {
                return new Models.Store.StoreShippingTbl();
            }
        }
        private async Task<List<Models.Store.StoreShippingAreaTbl>> getByStoreIdArea(float storeId)
        {
            var command = new
            {
                StoreId = storeId
            };

            try
            {
                var ret = await ServiceCaller.PostDataWithValue<List<Models.Store.StoreShippingAreaTbl>>("Setting/StoreShipping/GetByStoreIdArea", command);
                if (ret != null && ret.IsSuccess)
                {
                    return ret.Value;
                }
                else
                {
                    return new List<Models.Store.StoreShippingAreaTbl>();
                }
            }
            catch (Exception ex)
            {
                return new List<Models.Store.StoreShippingAreaTbl>();
            }
        }

        //---------------------------------------------
        //---------------------------------------------
        public async Task<FluentResult> Create(Models.Store.StoreShippingTbl model)
        {

            try
            {
                var ret = await ServiceCaller.PostDataWithoutValue("Setting/StoreShipping/Create", model);
                if(ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.StoreShipping);
                }
                return ret;

            }
            catch (Exception ex)
            {
                return new FluentResult();
            }
        }
        public async Task<FluentResult> CreateArea(Models.Store.StoreShippingAreaTbl model)
        {

            try
            {
                var ret = await ServiceCaller.PostDataWithoutValue("Setting/StoreShipping/CreateArea", model);
                if (ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.StoreShippingArea);
                }
                return ret;
            }
            catch (Exception ex)
            {
                return new FluentResult();
            }
        }

        //---------------------------------------------
        //---------------------------------------------
        public async Task<FluentResult> Update(Models.Store.StoreShippingTbl model)
        {

            try
            {
                var ret = await ServiceCaller.PostDataWithoutValue("Setting/StoreShipping/Update", model);
                if (ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.StoreShipping);
                }
                return ret;

            }
            catch (Exception ex)
            {
                return new FluentResult();
            }
        }
        public async Task<FluentResult> UpdateArea(Models.Store.StoreShippingAreaTbl model)
        {

            try
            {
                var ret = await ServiceCaller.PostDataWithoutValue("Setting/StoreShipping/UpdateArea", model);
                if (ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.StoreShippingArea);
                }
                return ret;
            }
            catch (Exception ex)
            {
                return new FluentResult();
            }
        }

        //---------------------------------------------
        //---------------------------------------------
        public async Task<FluentResult> DeleteArea(int id)
        {
            var command = new
            {
                Id = id
            };

            try
            {
                var ret = await ServiceCaller.PostDataWithoutValue("Setting/StoreShipping/DeleteArea", command);
                if (ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.StoreShippingArea);
                }
                return ret;

            }
            catch (Exception ex)
            {
                return new FluentResult();
            }
        }

        //----------------------------------------------
        //----------------------------------------------
        public async Task<Models.Store.StoreShippingTbl> GetByIdAsync(int id)
        {
            string key = $"StoreShippingGetId-{id}";
            var ret = await CacheService.GetAsync<Models.Store.StoreShippingTbl>(key);
            if (ret == null)
            {
                ret = await getById(id);
                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(30),
                    TimeSpan.FromMinutes(20),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.StoreShipping
                    );
            }

            return ret;
        }
        public async Task<Models.Store.StoreShippingAreaTbl> GetByIdAreaAsync(int id)
        {
            string key = $"StoreShippingAreaGetId-{id}";
            var ret = await CacheService.GetAsync<Models.Store.StoreShippingAreaTbl>(key);
            if (ret == null)
            {
                ret = await getByIdArea(id);
                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(30),
                    TimeSpan.FromMinutes(20),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.StoreShippingArea
                    );
            }

            return ret;
        }

        //----------------------------------------------
        //----------------------------------------------
        public async Task<List<Models.Store.StoreShippingTbl>> GetAllAsync()
        {
            string key = $"StoreShippingGetAll";
            var ret = await CacheService.GetAsync<List<Models.Store.StoreShippingTbl>>(key);
            if (ret == null)
            {
                ret = await getAll();
                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(30),
                    TimeSpan.FromMinutes(20),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.StoreShipping
                    );
            }

            return ret;
        }
        public async Task<List<Models.Store.StoreShippingAreaTbl>> GetAllAreaAsync()
        {
            string key = $"StoreShippingAreaGetAll";
            var ret = await CacheService.GetAsync<List<Models.Store.StoreShippingAreaTbl>>(key);
            if (ret == null)
            {
                ret = await getAllArea();
                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(30),
                    TimeSpan.FromMinutes(20),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.StoreShippingArea
                    );
            }

            return ret;
        }

        //----------------------------------------------
        //----------------------------------------------
        public async Task<Models.Store.StoreShippingTbl> GetByStoreIdAsync(float storeId)
        {
            string key = $"StoreShippingGetStoreId-{storeId}";
            var ret = await CacheService.GetAsync<Models.Store.StoreShippingTbl>(key);
            if (ret == null)
            {
                ret = await getByStoreId(storeId);
                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(30),
                    TimeSpan.FromMinutes(20),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.StoreShipping
                    );
            }

            return ret;
        }
        public async Task<List<Models.Store.StoreShippingAreaTbl>> GetByStoreIdAreaAsync(float storeId)
        {
            string key = $"StoreShippingAreaGetStoreId-{storeId}";
            var ret = await CacheService.GetAsync<List<Models.Store.StoreShippingAreaTbl>>(key);
            if (ret == null)
            {
                ret = await getByStoreIdArea(storeId);
                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(30),
                    TimeSpan.FromMinutes(20),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.StoreShippingArea
                    );
            }

            return ret;
        }
    }
}
