using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSite.JourChin.Helper;

namespace WebSite.JourChin.Services.Product
{
    public interface IProductService
    {
        Task<FluentResults.Result<BehsamFramework.Models.ProductReserveModel>> GetProductFprReserve(Models.Product.ProductReserveSearchModel item);
        Task<FluentResults.Result<Models.Product.ProductInfoModel>> GetProductByBarcode(float storeId, string barcode);
    }
    public class ProductService : Base.ServiceBase,IProductService
    {
        public ProductService(ICachedMemoryService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {

        }

        public async Task<FluentResults.Result<BehsamFramework.Models.ProductReserveModel>> GetProductFprReserve(Models.Product.ProductReserveSearchModel item)
        {
            FluentResults.Result<BehsamFramework.Models.ProductReserveModel> result = new FluentResults.Result<BehsamFramework.Models.ProductReserveModel>();

            try
            {
                result = await ServiceCaller.PostDataWithValue<BehsamFramework.Models.ProductReserveModel>("Setting/Store/GetProductsReserve", item);
            }
            catch (Exception ex)
            {
                result.WithValue(new BehsamFramework.Models.ProductReserveModel());
                result.WithError(ex.Message);
            }

            return result;
        }

        public async Task<FluentResults.Result<Models.Product.ProductInfoModel>> GetProductByBarcode(float storeId,string barcode)
        {
            FluentResults.Result<Models.Product.ProductInfoModel> result = new FluentResults.Result<Models.Product.ProductInfoModel>();
            var item = new
            {
                StoreId = storeId,
                Barcode = barcode
            };

            try
            {
                result = await ServiceCaller.PostDataWithValue<Models.Product.ProductInfoModel>("Setting/Store/GetProductsByBarcode", item);
            }
            catch (Exception ex)
            {
                result.WithValue(new Models.Product.ProductInfoModel());
                result.WithError(ex.Message);
            }

            return result;
        }
    }



}
