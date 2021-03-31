using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;
using BehsamFramework.Models;

namespace WebSites.Panles.Services.Store
{
    public interface IGetProductByCategoryService
    {
        Task<List<BehsamFramework.Models.ProductShowModel>> Execute(float categoryId);
    }

    public class GetProductByCategoryService : Base.ServiceBase, IGetProductByCategoryService
    {
        public GetProductByCategoryService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public async Task<List<ProductShowModel>> Execute(float categoryId)
        {
            List<ProductShowModel> ret = await GetService(categoryId);

            if (ret == null)
            {
                ret = new List<ProductShowModel>();
            }
            string key = "GetProductByCategory" + categoryId.ToString();
            ret = await CacheService.GetOrSetAsync(
                ret,
                key,
                TimeSpan.FromMinutes(20),
                TimeSpan.FromMinutes(5),
                Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                TokenCachClass.CatgoryToken
                );

            return ret;
        }
        private async Task<List<ProductShowModel>> GetService(float categoryId)
        {
            List<ProductShowModel> result = new List<ProductShowModel>();

            var Command = new
            {
                CategoryId = categoryId
            };

            FluentResult<List<BehsamFramework.Models.ProductShowModel>> model =
                new FluentResult<List<ProductShowModel>>();

            try
            {
                model = await ServiceCaller.PostDataWithValue<List<ProductShowModel>>("Setting/GetProductByCategory", Command);


                if (model == null || model.Value == null || model.IsFailed)
                {
                    throw new Exception("اطلاعات یافت نشد");
                }

            }
            catch (Exception ex)
            {
                model = new FluentResult<List<ProductShowModel>>()
                {
                    Value = new List<ProductShowModel>()
                };
                model.WithError(ex.Message);
            }

            return model.Value;
        }
    }
}
