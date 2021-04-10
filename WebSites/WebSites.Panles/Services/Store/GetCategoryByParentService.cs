using AutoMapper;
using BehsamFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Store
{
    public interface IGetCategoryByParentService
    {
        Task<List<BehsamFramework.Models.CategoryShowModel>> Execute(decimal categoryId);
    }

    public class GetCategoryByParentService : Base.ServiceBase, IGetCategoryByParentService
    {
        public GetCategoryByParentService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public async Task<List<CategoryShowModel>> Execute(decimal categoryId)
        {
            List<CategoryShowModel> ret = new List<CategoryShowModel>(); //await GetService(categoryId);

            //if (ret == null)
            //{
            //    ret = new List<CategoryShowModel>();
            //}
            string key = "CategoryShowModel" + categoryId.ToString();
            ret = await CacheService.GetOrSetAsync(
                ret,
                categoryId,
                key,
                TimeSpan.FromMinutes(20),
                TimeSpan.FromMinutes(5),
                Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                TokenCachClass.CatgoryToken,
                GetService
                );

            return ret;
        }
        private async Task<List<CategoryShowModel>> GetService(decimal categoryId)
        {
            List<CategoryShowModel> result = new List<CategoryShowModel>();

            var Command = new
            {
                CategoryId=categoryId
            };

            FluentResult<List<BehsamFramework.Models.CategoryShowModel>> model =
                new FluentResult<List<CategoryShowModel>>();

            try
            {
                model = await ServiceCaller.PostDataWithValue<List<CategoryShowModel>>("Setting/Store/GetCategory", Command);


                if (model == null || model.Value == null || model.IsFailed)
                {
                    throw new Exception("اطلاعات یافت نشد");
                }

            }
            catch (Exception ex)
            {
                model = new FluentResult<List<CategoryShowModel>>()
                {
                    Value = new List<CategoryShowModel>()
                };
                model.WithError(ex.Message);
            }

            return model.Value;
        }
    }
}
