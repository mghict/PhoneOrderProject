using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Store
{
    public interface IGetStoreInfoPaginationService
    {
        Task<BehsamFramework.Models.StoreInfoListModel> GetStoresAsync(int page = 1, int pageSize = 20, string searchKey = "");
    }
    public class GetStoreInfoPaginationService : Base.ServiceBase, IGetStoreInfoPaginationService
    {
        public GetStoreInfoPaginationService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public async Task<BehsamFramework.Models.StoreInfoListModel> GetStoresAsync(int page = 1, int pageSize = 20, string searchKey = "")
        {
            BehsamFramework.Models.StoreInfoListModel ret = new BehsamFramework.Models.StoreInfoListModel();
            string key = $"GetStores-{page}-{pageSize}";
            ret = await CacheService.GetOrSetAsync(
                                                    ret,
                                                    key,
                                                    TimeSpan.FromHours(8),
                                                    TimeSpan.FromHours(1),
                                                    Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                                                    TokenCachClass.StoreToken
                                                    );

            if (ret == null)
            {
                ret = await GetStores(page, pageSize, searchKey);
                ret = await CacheService.GetOrSetAsync(
                                                        ret,
                                                        key,
                                                        TimeSpan.FromHours(8),
                                                        TimeSpan.FromHours(1),
                                                        Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                                                        TokenCachClass.StoreToken
                                                        );
            }

            return ret;
        }

        private async Task<BehsamFramework.Models.StoreInfoListModel> GetStores(int page = 1, int pageSize = 20, string searchKey = "")
        {
            BehsamFramework.Models.StoreInfoListModel retVal =
                new BehsamFramework.Models.StoreInfoListModel();
            try
            {
                var command = new
                {
                    SearchKey = searchKey,
                    PageNumber = page,
                    PageSize = pageSize
                };

                var result = await ServiceCaller.PostDataWithValue<BehsamFramework.Models.StoreInfoListModel>("Setting/Store/GetStorePagination", command);
                if (result.IsSuccess)
                {
                    retVal = result.Value;
                    return retVal;
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
    }
}
