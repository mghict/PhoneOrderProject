using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.InActive
{
    public interface IInActive
    {
        Task<List<Models.InActive.InActiveTbl>> GetAll();
        Task<Models.InActive.InActiveTbl> GetById(int id);
        Task<FluentResult> Remove(int id);
        Task<FluentResult> Create(Models.InActive.InActiveTbl input);
        Task<FluentResult> Update(Models.InActive.InActiveTbl input);

        //--------------------------------------------------------------------
        // StoreInActive
        //--------------------------------------------------------------------
        Task<FluentResult> CreateStoreInActive(Models.InActive.StoreInActiveTbl input);
        Task<FluentResult> UpdateStoreInActive(Models.InActive.StoreInActiveTbl input);
        Task<FluentResult> RemoveStoreInActive(int id);
        Task<Models.InActive.StoreInActiveTbl> GetByIdStoreInActive(int id);
        Task<List<Models.InActive.StoreInActiveTbl>> GetAllStoreInActive(float storeId);
    }
    public class InActiveService : Base.ServiceBase, IInActive
    {
        public InActiveService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public async Task<List<Models.InActive.InActiveTbl>> GetAll()
        {
            List<Models.InActive.InActiveTbl> ret = new List<Models.InActive.InActiveTbl>();
            try
            {
                ret = await CacheService.GetOrSetAsync(
                    ret,
                    "InActive",
                    TimeSpan.FromHours(8),
                    TimeSpan.FromHours(1),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.InActiveToken,
                    getAll
                    ) ;
            }
            catch
            {
                ret = new List<Models.InActive.InActiveTbl>();
            }

            return ret;
        }
        private async Task<List<Models.InActive.InActiveTbl>> getAll()
        {
            List<Models.InActive.InActiveTbl> ret =
                new List<Models.InActive.InActiveTbl>();

            var command = new { };
            try
            {
                var resp =await ServiceCaller.PostDataWithValue<List<Models.InActive.InActiveTbl>>("Setting/InActive/GetAll", command);
                if(resp!=null && resp.IsSuccess && resp.Value!=null && resp.Value.Count>0)
                {
                    ret = resp.Value;
                }
            }
            catch
            {
                ret =new List<Models.InActive.InActiveTbl>();
            }

            return ret;
        }


        public async Task<Models.InActive.InActiveTbl> GetById(int id)
        {
            Models.InActive.InActiveTbl ret = new Models.InActive.InActiveTbl();
            try
            {
                ret = await CacheService.GetOrSetAsync(
                    ret,
                    id,
                    $"InActive-{id}",
                    TimeSpan.FromHours(8),
                    TimeSpan.FromHours(1),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.InActiveToken,
                    getById
                    );
            }
            catch
            {
                ret = new Models.InActive.InActiveTbl();
            }

            return ret;
        }
        private async Task<Models.InActive.InActiveTbl> getById(int id)
        {
            Models.InActive.InActiveTbl ret =
                new Models.InActive.InActiveTbl();

            var command = new {
                Id=id
            };

            try
            {
                var resp = await ServiceCaller.PostDataWithValue<Models.InActive.InActiveTbl>("Setting/InActive/GetById", command);
                if (resp != null && resp.IsSuccess && resp.Value != null)
                {
                    ret = resp.Value;
                }
            }
            catch
            {
                ret = new Models.InActive.InActiveTbl();
            }

            return ret;
        }

        public async Task<FluentResult> Update(Models.InActive.InActiveTbl input)
        {
            FluentResult ret =
                new FluentResult();

            try
            {
                ret = await ServiceCaller.PostDataWithoutValue("Setting/InActive/Update", input);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.InActiveToken);
                }
            }
            catch(Exception ex)
            {
                ret.IsFailed = true;
                ret.WithError(ex.Message);
            }

            return ret;
        }

        public async Task<FluentResult> Create(Models.InActive.InActiveTbl input)
        {
            FluentResult ret =
                new FluentResult();

            try
            {
                ret = await ServiceCaller.PostDataWithoutValue("Setting/InActive/Create", input);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.InActiveToken);
                }
            }
            catch (Exception ex)
            {
                ret.IsFailed = true;
                ret.WithError(ex.Message);
            }

            return ret;
        }

        public async Task<FluentResult> Remove(int id)
        {
            FluentResult ret =
                new FluentResult();

            var command = new
            {
                Id = id
            };

            try
            {
                ret = await ServiceCaller.PostDataWithoutValue("Setting/InActive/Remove", command);
                if(ret!=null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.InActiveToken);
                }
            }
            catch (Exception ex)
            {
                ret.IsFailed = true;
                ret.WithError(ex.Message);
            }

            return ret;
        }

        //--------------------------------------------------------------------
        // StoreInActive
        //--------------------------------------------------------------------

        public async Task<FluentResult> CreateStoreInActive(Models.InActive.StoreInActiveTbl input)
        {
            FluentResult ret =
                new FluentResult();

            try
            {
                ret = await ServiceCaller.PostDataWithoutValue("Setting/InActive/CreateStoreInActive", input);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.StoreInActiveToken);
                }
            }
            catch (Exception ex)
            {
                ret.IsFailed = true;
                ret.WithError(ex.Message);
            }

            return ret;
        }

        public async Task<FluentResult> UpdateStoreInActive(Models.InActive.StoreInActiveTbl input)
        {
            FluentResult ret =
                new FluentResult();

            try
            {
                ret = await ServiceCaller.PostDataWithoutValue("Setting/InActive/UpdateStoreInActive", input);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.StoreInActiveToken);
                }
            }
            catch (Exception ex)
            {
                ret.IsFailed = true;
                ret.WithError(ex.Message);
            }

            return ret;
        }

        public async Task<FluentResult> RemoveStoreInActive(int id)
        {
            FluentResult ret =
                new FluentResult();

            var command = new
            {
                Id = id
            };

            try
            {
                ret = await ServiceCaller.PostDataWithoutValue("Setting/InActive/RemoveStoreInActive", command);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.StoreInActiveToken);
                }
            }
            catch (Exception ex)
            {
                ret.IsFailed = true;
                ret.WithError(ex.Message);
            }

            return ret;
        }

        private async Task<Models.InActive.StoreInActiveTbl> getByIdStoreInActive(int id)
        {
            Models.InActive.StoreInActiveTbl ret =
                new Models.InActive.StoreInActiveTbl();

            var command = new
            {
                Id = id
            };

            try
            {
                var resp = await ServiceCaller.PostDataWithValue<Models.InActive.StoreInActiveTbl>("Setting/InActive/GetByIdStoreInActive", command);
                if (resp != null && resp.IsSuccess && resp.Value != null)
                {
                    ret = resp.Value;
                }
            }
            catch
            {
                ret = new Models.InActive.StoreInActiveTbl();
            }

            return ret;
        }
        public async Task<Models.InActive.StoreInActiveTbl> GetByIdStoreInActive(int id)
        {
            Models.InActive.StoreInActiveTbl ret = new Models.InActive.StoreInActiveTbl();
            try
            {
                ret = await CacheService.GetOrSetAsync(
                    ret,
                    id,
                    $"StoreInActive-{id}",
                    TimeSpan.FromHours(8),
                    TimeSpan.FromHours(1),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.StoreInActiveToken,
                    getByIdStoreInActive
                    );
            }
            catch
            {
                ret = new Models.InActive.StoreInActiveTbl();
            }

            return ret;
        }


        private async Task<List<Models.InActive.StoreInActiveTbl>> getAllStoreInActive(float storeId)
        {
            List<Models.InActive.StoreInActiveTbl> ret =
                new List<Models.InActive.StoreInActiveTbl>();

            var command = new
            {
                StoreId = storeId
            };

            try
            {
                var resp = await ServiceCaller.PostDataWithValue<List<Models.InActive.StoreInActiveTbl>>("Setting/InActive/GetAllStoreInActive", command);
                if (resp != null && resp.IsSuccess && resp.Value != null && resp.Value.Count > 0)
                {
                    ret = resp.Value;
                }
            }
            catch
            {
                ret = new List<Models.InActive.StoreInActiveTbl>();
            }

            return ret;
        }
        public async Task<List<Models.InActive.StoreInActiveTbl>> GetAllStoreInActive(float storeId)
        {
            List<Models.InActive.StoreInActiveTbl> ret = new List<Models.InActive.StoreInActiveTbl>();
            try
            {
                ret = await CacheService.GetOrSetAsync(
                    ret,
                    storeId,
                    $"StoreInActive-{storeId}",
                    TimeSpan.FromHours(8),
                    TimeSpan.FromHours(1),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.StoreInActiveToken,
                    getAllStoreInActive
                    );
            }
            catch
            {
                ret = new List<Models.InActive.StoreInActiveTbl>();
            }

            return ret;
        }
        
    }
}
