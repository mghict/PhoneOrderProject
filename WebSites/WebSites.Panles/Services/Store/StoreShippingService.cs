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
        //----------------------------------------------
        // Global Shipping
        //----------------------------------------------
        Task<FluentResult> UpdateGlobal(Models.Store.StoreGeneralShippingModel model);
        Task<Models.Store.StoreGeneralShippingModel> GetGlobalAsync();

        //----------------------------------------------
        // Global Shipping By Price
        //----------------------------------------------
        Task<FluentResult> CreateGlobalPrice(Models.Store.StoreGeneralShippingPriceModel model);
        Task<FluentResult> UpdateGlobalPrice(Models.Store.StoreGeneralShippingPriceModel model);
        Task<FluentResult> DeleteGlobalPrice(int id);
        Task<Models.Store.StoreGeneralShippingPriceModel> GetByIdGlobalPrice(int id);
        Task<List<Models.Store.StoreGeneralShippingPriceModel>> GetAllGlobalPrice();
        Task<List<Models.Store.StoreGeneralShippingPriceModel>> GetRangeGlobalPrice(int fromAmount, int toAmount);
        Task<List<Models.Store.StoreGeneralShippingPriceModel>> GetRangeByAmountGlobalPrice(int amount);

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

        //----------------------------------------------
        // Global Shipping
        //----------------------------------------------
        public async Task<FluentResult> UpdateGlobal(Models.Store.StoreGeneralShippingModel model)
        {

            try
            {
                var ret = await ServiceCaller.PostDataWithoutValue("Setting/StoreShipping/UpdateGlobal", model);
                if (ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.GlobalShipping);
                }
                return ret;

            }
            catch (Exception ex)
            {
                return new FluentResult();
            }
        }

        private async Task<Models.Store.StoreGeneralShippingModel> getGlobal()
        {
            var command = new
            {
                
            };

            try
            {
                var ret = await ServiceCaller.PostDataWithValue<Models.Store.StoreGeneralShippingModel>("Setting/StoreShipping/GetByIdGlobal", command);
                if (ret != null && ret.IsSuccess)
                {
                    return ret.Value;
                }
                else
                {
                    return new Models.Store.StoreGeneralShippingModel();
                }
            }
            catch (Exception ex)
            {
                return new Models.Store.StoreGeneralShippingModel();
            }
        }

        public async Task<Models.Store.StoreGeneralShippingModel> GetGlobalAsync()
        {
            string key = $"GlobalShipping";
            var ret = await CacheService.GetAsync<Models.Store.StoreGeneralShippingModel>(key);
            if (ret == null)
            {
                ret = await getGlobal();
                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(30),
                    TimeSpan.FromMinutes(20),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.GlobalShipping
                    );
            }

            return ret;
        }

        //----------------------------------------------
        // Global Shipping By Price
        //----------------------------------------------
        public async Task<FluentResult> CreateGlobalPrice(Models.Store.StoreGeneralShippingPriceModel model)
        {

            try
            {
                var ret = await ServiceCaller.PostDataWithoutValue("Setting/StoreShipping/CreateShippingByPrice", model);
                if (ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.GlobalShippingPrice);
                }
                return ret;

            }
            catch (Exception ex)
            {
                return new FluentResult();
            }
        }
        public async Task<FluentResult> UpdateGlobalPrice(Models.Store.StoreGeneralShippingPriceModel model)
        {

            try
            {
                var ret = await ServiceCaller.PostDataWithoutValue("Setting/StoreShipping/UpdateShippingByPrice", model);
                if (ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.GlobalShippingPrice);
                }
                return ret;

            }
            catch (Exception ex)
            {
                return new FluentResult();
            }
        }
        public async Task<FluentResult> DeleteGlobalPrice(int id)
        {
            var model = new
            {
                Id=id
            };

            try
            {
                var ret = await ServiceCaller.PostDataWithoutValue("Setting/StoreShipping/DeleteShippingByPrice", model);
                if (ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.GlobalShippingPrice);
                }
                return ret;

            }
            catch (Exception ex)
            {
                return new FluentResult();
            }
        }


        private async Task<Models.Store.StoreGeneralShippingPriceModel> getByIdGlobalPrice(int id)
        {
            var command = new
            {
                Id=id
            };

            try
            {
                var ret = await ServiceCaller.PostDataWithValue<Models.Store.StoreGeneralShippingPriceModel>("Setting/StoreShipping/GetByIdShippingByPrice", command);
                if (ret != null && ret.IsSuccess && ret.Value!=null)
                {
                    return ret.Value;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private async Task<List<Models.Store.StoreGeneralShippingPriceModel>> getAllGlobalPrice()
        {
            var command = new
            {
                
            };

            try
            {
                var ret = await ServiceCaller.PostDataWithValue<List<Models.Store.StoreGeneralShippingPriceModel>>("Setting/StoreShipping/GetAllShippingByPrice", command);
                if (ret != null && ret.IsSuccess && ret.Value != null && ret.Value.Count>0)
                {
                    return ret.Value;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private async Task<List<Models.Store.StoreGeneralShippingPriceModel>> getRangeGlobalPrice(int fromAmount,int toAmount)
        {
            var command = new
            {
                FromAmount=fromAmount,
                ToAmount=toAmount
            };

            try
            {
                var ret = await ServiceCaller.PostDataWithValue<List<Models.Store.StoreGeneralShippingPriceModel>>("Setting/StoreShipping/GetRangeShippingByPrice", command);
                if (ret != null && ret.IsSuccess && ret.Value != null && ret.Value.Count > 0)
                {
                    return ret.Value;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private async Task<List<Models.Store.StoreGeneralShippingPriceModel>> getRangeByAmountGlobalPrice(int amount)
        {
            var command = new
            {
                Amount = amount
            };

            try
            {
                var ret = await ServiceCaller.PostDataWithValue<List<Models.Store.StoreGeneralShippingPriceModel>>("Setting/StoreShipping/GetRangeByAmountShippingByPrice", command);
                if (ret != null && ret.IsSuccess && ret.Value != null && ret.Value.Count > 0)
                {
                    return ret.Value;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<Models.Store.StoreGeneralShippingPriceModel> GetByIdGlobalPrice(int id)
        {
            string key = $"GlobalShippingPriceById-{id}";
            var ret = await CacheService.GetAsync<Models.Store.StoreGeneralShippingPriceModel>(key);
            if (ret == null)
            {
                ret = await getByIdGlobalPrice(id);
                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(30),
                    TimeSpan.FromMinutes(20),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.GlobalShippingPrice
                    );
            }

            return ret;
        }
        public async Task<List<Models.Store.StoreGeneralShippingPriceModel>> GetAllGlobalPrice()
        {
            string key = $"GlobalShippingPriceAll";
            var ret = await CacheService.GetAsync<List<Models.Store.StoreGeneralShippingPriceModel>>(key);
            if (ret == null)
            {
                ret = await getAllGlobalPrice();
                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(30),
                    TimeSpan.FromMinutes(20),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.GlobalShippingPrice
                    );
            }

            return ret;
        }
        public async Task<List<Models.Store.StoreGeneralShippingPriceModel>> GetRangeGlobalPrice(int fromAmount, int toAmount)
        {
            string key = $"GlobalShippingPriceByRange-{fromAmount}-{toAmount}";
            var ret = await CacheService.GetAsync<List<Models.Store.StoreGeneralShippingPriceModel>>(key);
            if (ret == null)
            {
                ret = await getRangeGlobalPrice(fromAmount,toAmount);
                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(30),
                    TimeSpan.FromMinutes(20),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.GlobalShippingPrice
                    );
            }

            return ret;
        }
        public async Task<List<Models.Store.StoreGeneralShippingPriceModel>> GetRangeByAmountGlobalPrice(int amount)
        {
            string key = $"GlobalShippingPriceByAmount-{amount}";
            var ret = await CacheService.GetAsync<List<Models.Store.StoreGeneralShippingPriceModel>>(key);
            if (ret == null)
            {
                ret = await getRangeByAmountGlobalPrice(amount);
                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(30),
                    TimeSpan.FromMinutes(20),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.GlobalShippingPrice
                    );
            }

            return ret;
        }
    }
}
