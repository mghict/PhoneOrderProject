using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Store
{
    public interface IProductService
    {
        Task<BehsamFramework.Models.ProductsModel> GetProductsAllAsync(string searchKey = "", int pageNumber = 0, int pageSize = 20);
        Task<BehsamFramework.Models.ProductsModel> GetProductsAllByStoreAsync(float storeId, string searchKey = "", int pageNumber = 0, int pageSize = 20);
    }
    public class ProductService : Base.ServiceBase, IProductService
    {
        public ProductService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public async Task<BehsamFramework.Models.ProductsModel> GetProductsAllAsync(string searchKey="",int pageNumber=0,int pageSize=20)
        {
            var ret=  new BehsamFramework.Models.ProductsModel()
                {
                    RowCount = 0,
                    Products = new List<BehsamFramework.Models.ProductShowModel>()
                };

            string key = $"GetProductsAll-{searchKey}-{pageNumber}-{pageSize}";

            ret = await CacheService.GetAsync<BehsamFramework.Models.ProductsModel>(key);

            if(ret==null || ret.Products==null || ret.Products.Count==0)
            {
                ret =await getProductsAllAsync(searchKey, pageNumber, pageSize);

                await CacheService.RemoveAndSetAsync(
                ret,
                key,
                TimeSpan.FromMinutes(20),
                TimeSpan.FromMinutes(5),
                Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                TokenCachClass.Product
                );

            }

            return ret;
        }

        private async Task<BehsamFramework.Models.ProductsModel> getProductsAllAsync(string searchKey = "", int pageNumber = 0, int pageSize=20)
        {
            var command = new
            {
                SearchKey = searchKey,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            FluentResult<BehsamFramework.Models.ProductsModel> model =
                new FluentResult<BehsamFramework.Models.ProductsModel>()
                {
                    Value = new BehsamFramework.Models.ProductsModel()
                    {
                        RowCount = 0,
                        Products = new List<BehsamFramework.Models.ProductShowModel>()
                    }
                };

            try
            {
                model = await ServiceCaller.PostDataWithValue<BehsamFramework.Models.ProductsModel>("Setting/Store/GetProductsAll", command);


                if (model == null || model.Value == null || model.IsFailed)
                {
                    throw new Exception("اطلاعات یافت نشد");
                }

            }
            catch (Exception ex)
            {
                model = new FluentResult<BehsamFramework.Models.ProductsModel>()
                {
                    Value = new BehsamFramework.Models.ProductsModel()
                    {
                        RowCount = 0,
                        Products = new List<BehsamFramework.Models.ProductShowModel>()
                    }
                };

                model.WithError(ex.Message);
            }

            return model.Value;
        }

        public async Task<BehsamFramework.Models.ProductsModel> GetProductsAllByStoreAsync(float storeId, string searchKey = "", int pageNumber = 0, int pageSize=20)
        {
            var ret = new BehsamFramework.Models.ProductsModel()
            {
                RowCount = 0,
                Products = new List<BehsamFramework.Models.ProductShowModel>()
            };

            string key = $"GetProductsAllByStore-{searchKey}-{pageNumber}-{pageSize}";
            ret = await CacheService.GetAsync< BehsamFramework.Models.ProductsModel>(key);

            if (ret == null || ret.Products == null || ret.Products.Count == 0)
            {
                ret = await getProductsAllByStoreAsync(storeId,searchKey, pageNumber, pageSize);

                await CacheService.RemoveAndSetAsync(
                ret,
                key,
                TimeSpan.FromMinutes(20),
                TimeSpan.FromMinutes(5),
                Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                TokenCachClass.Product
                );

            }

            return ret;
        }

        private async Task<BehsamFramework.Models.ProductsModel> getProductsAllByStoreAsync(float storeId,string searchKey = "", int pageNumber = 0, int pageSize=20)
        {
            var command = new
            {
                StoreId=storeId,
                SearchKey = searchKey,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            FluentResult<BehsamFramework.Models.ProductsModel> model =
                new FluentResult<BehsamFramework.Models.ProductsModel>()
                {
                    Value = new BehsamFramework.Models.ProductsModel()
                    {
                        RowCount = 0,
                        Products = new List<BehsamFramework.Models.ProductShowModel>()
                    }
                };

            try
            {
                model = await ServiceCaller.PostDataWithValue<BehsamFramework.Models.ProductsModel>("Setting/Store/GetProductsAllByStore", command);


                if (model == null || model.Value == null || model.IsFailed)
                {
                    throw new Exception("اطلاعات یافت نشد");
                }

            }
            catch (Exception ex)
            {
                model = new FluentResult<BehsamFramework.Models.ProductsModel>()
                {
                    Value = new BehsamFramework.Models.ProductsModel()
                    {
                        RowCount = 0,
                        Products = new List<BehsamFramework.Models.ProductShowModel>()
                    }
                };

                model.WithError(ex.Message);
            }

            return model.Value;
        }


    }
}
