using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Area
{
    public interface IAreaInfoService
    {
        Task<Models.Area.AreaInfoModel> GetByIdAsync(int areaId);
        Task<Models.Area.AreaInfo> GetAllBySearchAsync(string searchKey = "", int pageNumber = 0, int pageSize = 20);
        Task<List<Models.Area.AreaInfoModel>> GetAllAsync();
        Task<List<Models.Area.AreaInfoModel>> GetByCityAsync(int cityId, int areaType = 0);
        Task<List<Models.Area.AreaInfoModel>> GetByParentAsync(int parentId, int areaType = 0);
        Task<List<Models.AttributeStatus>> GetAllAreaTypeAsync();
        Task<FluentResult> CreateAsync(Models.Area.AreaInfoModel model);
        Task<FluentResult> UpdateAsync(Models.Area.AreaInfoModel model);
        Task<FluentResult> DeleteAsync(int id);
        Task<List<Models.Area.AreaGeoTbl>> GetGeoByAreaId(int areaId);
        Task<FluentResult> CreateGeoAsync(List<Models.Area.AreaGeoTbl> model);
    }
    public class AreaInfoService : Base.ServiceBase,IAreaInfoService
    {
        public AreaInfoService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        private async Task<Models.Area.AreaInfo> getAllBySearch(string searchKey="",int pageNumber=0,int pageSize=20)
        {
            var command = new
            {
                SearchKey = searchKey,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            try
            {
                var ret = await ServiceCaller.PostDataWithValue<Models.Area.AreaInfo>("Setting/Area/GetAllBySearch", command);
                if (ret != null && ret.IsSuccess)
                {
                    return ret.Value;
                }
                else
                {
                    return new Models.Area.AreaInfo();
                }
            }
            catch (Exception ex)
            {
                return new Models.Area.AreaInfo();
            }
        }
        public async Task<Models.Area.AreaInfo> GetAllBySearchAsync(string searchKey = "", int pageNumber = 0, int pageSize = 20)
        {
            string key = $"GetAllBySearch-{searchKey}-{pageNumber}-{pageSize}";
            var ret = await CacheService.GetAsync<Models.Area.AreaInfo>(key);
            if (ret == null || ret.Areas==null || ret.Areas.Count==0)
            {
                ret = await getAllBySearch(searchKey,pageNumber,pageSize);
                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(15),
                    TimeSpan.FromMinutes(5),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.Area
                    );
            }

            return ret;
        }

        private async Task<Models.Area.AreaInfoModel> getById(int areaId)
        {
            var command = new
            {
                Id = areaId
            };

            try
            {
                var ret = await ServiceCaller.PostDataWithValue<Models.Area.AreaInfoModel>("Setting/Area/GetById", command);
                if(ret!=null && ret.IsSuccess)
                {
                    return ret.Value;
                }
                else
                {
                    return new Models.Area.AreaInfoModel();
                }
            }
            catch(Exception ex)
            {
                return new Models.Area.AreaInfoModel();
            }
        }
        public async Task<Models.Area.AreaInfoModel> GetByIdAsync(int areaId)
        {
            string key = $"AreaGetId-{areaId}";
            var ret = await CacheService.GetAsync<Models.Area.AreaInfoModel>(key);
            if(ret==null)
            {
                ret = await getById(areaId);
                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(15),
                    TimeSpan.FromMinutes(5),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.Area
                    );
            }

            return ret;
        }
        
        private async Task<List<Models.Area.AreaInfoModel>> getAll()
        {
            try
            {
                var ret = await ServiceCaller.GetDataWithValue<List<Models.Area.AreaInfoModel>>("Setting/Area/GetAll");
                if (ret != null && ret.IsSuccess)
                {
                    return ret.Value;
                }
                else
                {
                    return new List<Models.Area.AreaInfoModel>();
                }
            }
            catch (Exception ex)
            {
                return new List<Models.Area.AreaInfoModel>();
            }
        }
        public async Task<List<Models.Area.AreaInfoModel>> GetAllAsync()
        {
            string key = $"AreaGetAll";
            var ret = await CacheService.GetAsync<List<Models.Area.AreaInfoModel>>(key);
            if (ret == null)
            {
                ret = await getAll();
                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(15),
                    TimeSpan.FromMinutes(5),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.Area
                    );
            }

            return ret;
        }

        private async Task<List<Models.Area.AreaInfoModel>> getByCity(int cityId, int areaType = 0)
        {
            var command = new
            {
                CityId = cityId,
                AreaType= areaType
            };

            try
            {
                var ret = await ServiceCaller.PostDataWithValue<List<Models.Area.AreaInfoModel>>("Setting/Area/GetByCity", command);
                if (ret != null && ret.IsSuccess)
                {
                    return ret.Value;
                }
                else
                {
                    return new List<Models.Area.AreaInfoModel>();
                }
            }
            catch (Exception ex)
            {
                return new List<Models.Area.AreaInfoModel>();
            }
        }
        public async Task<List<Models.Area.AreaInfoModel>> GetByCityAsync(int cityId, int areaType = 0)
        {
            string key = $"AreaGetByCity-{cityId}-{areaType}";
            var ret = await CacheService.GetAsync<List<Models.Area.AreaInfoModel>>(key);
            if (ret == null)
            {
                ret = await getByCity(cityId, areaType);

                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(15),
                    TimeSpan.FromMinutes(5),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.Area
                    );
            }

            return ret;
        }

        private async Task<List<Models.Area.AreaInfoModel>> getByParent(int parentId,int areaType=0)
        {
            var command = new
            {
                ParentId = parentId,
                AreaType= areaType
            };

            try
            {
                var ret = await ServiceCaller.PostDataWithValue<List<Models.Area.AreaInfoModel>>("Setting/Area/GetByParent", command);
                if (ret != null && ret.IsSuccess)
                {
                    return ret.Value;
                }
                else
                {
                    return new List<Models.Area.AreaInfoModel>();
                }
            }
            catch (Exception ex)
            {
                return new List<Models.Area.AreaInfoModel>();
            }
        }
        public async Task<List<Models.Area.AreaInfoModel>> GetByParentAsync(int parentId, int areaType = 0)
        {
            string key = $"AreaGetByParent-{parentId}-{areaType}";
            var ret = await CacheService.GetAsync<List<Models.Area.AreaInfoModel>>(key);
            if (ret == null)
            {
                ret = await getByParent(parentId, areaType);

                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(15),
                    TimeSpan.FromMinutes(5),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.Area
                    );
            }

            return ret;
        }

        private async Task<List<Models.AttributeStatus>> getAllAreaType()
        {
            try
            {
                var ret = await ServiceCaller.GetDataWithValue<List<Models.AttributeStatus>>("Setting/Area/GetAllAreaType");
                if (ret != null && ret.IsSuccess)
                {
                    return ret.Value;
                }
                else
                {
                    return new List<Models.AttributeStatus>();
                }
            }
            catch (Exception ex)
            {
                return new List<Models.AttributeStatus>();
            }
        }
        public async Task<List<Models.AttributeStatus>> GetAllAreaTypeAsync()
        {
            string key = $"AreaGetAllAreaType";

            var ret = await CacheService.GetAsync<List<Models.AttributeStatus>>(key);
            if (ret == null)
            {
                ret = await getAllAreaType();
                await CacheService.RemoveAndSetAsync(
                    ret,
                    key,
                    TimeSpan.FromMinutes(15),
                    TimeSpan.FromMinutes(5),
                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                    TokenCachClass.AreaType
                    );
            }

            return ret;
        }

        public async Task<FluentResult> CreateAsync(Models.Area.AreaInfoModel model)
        {
            
            try
            {
                var ret = await ServiceCaller.PostDataWithoutValue("Setting/Area/Create", model);
                if(ret!=null && ret.IsSuccess)
                {

                    await CacheService.ClearTokenAsync(TokenCachClass.Area);
                }
                return ret;
            }
            catch (Exception ex)
            {
                return new FluentResult();
            }
        }
        public async Task<FluentResult> UpdateAsync(Models.Area.AreaInfoModel model)
        {

            try
            {
                var ret = await ServiceCaller.PostDataWithoutValue("Setting/Area/Update", model);
                if (ret != null && ret.IsSuccess)
                {
                    string key = $"AreaGetId-{model.Id}";
                    await CacheService.ClearCacheAsync(key);
                    await CacheService.ClearTokenAsync(TokenCachClass.Area);
                }
                return ret;
            }
            catch (Exception ex)
            {
                return new FluentResult();
            }
        }
        public async Task<FluentResult> DeleteAsync(int id)
        {
            var command = new
            {
                Id = id
            };

            try
            {
                var ret = await ServiceCaller.PostDataWithoutValue("Setting/Area/Delete", command);
                if (ret != null && ret.IsSuccess)
                {

                    await CacheService.ClearTokenAsync(TokenCachClass.Area);
                }
                return ret;
            }
            catch (Exception ex)
            {
                return new FluentResult();
            }
        }

        //------------------------------------
        //------------------------------------

        public  async Task<List<Models.Area.AreaGeoTbl>> GetGeoByAreaId(int areaId)
        {
            var command = new
            {
                AreaId = areaId
            };

            try
            {
                var ret = await ServiceCaller.PostDataWithValue<List<Models.Area.AreaGeoTbl>>("Setting/Area/GetGeoByAreaId", command);
                if (ret != null && ret.IsSuccess)
                {
                    return ret.Value;
                }
                else
                {
                    return new List<Models.Area.AreaGeoTbl>();
                }
            }
            catch (Exception ex)
            {
                return new List<Models.Area.AreaGeoTbl>();
            }
        }
        public async Task<FluentResult> CreateGeoAsync(List<Models.Area.AreaGeoTbl> model)
        {
            var command = new
            {
                Points = model.ToList()
            };

            try
            {
                var ret = await ServiceCaller.PostDataWithoutValue("Setting/Area/CreateAreaGeo", command);

                return ret;
            }
            catch (Exception ex)
            {
                return new FluentResult();
            }
        }
    }
}
