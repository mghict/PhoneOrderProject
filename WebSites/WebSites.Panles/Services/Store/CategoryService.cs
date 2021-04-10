using AutoMapper;
using BehsamFramework.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Store
{
    public interface ICategoryService
    {
        Task<BehsamFramework.Models.CategoriesModel> GetCategories(string catName, int pageNum, int pageSize);
    }
    public class CategoryService : Base.ServiceBase, ICategoryService
    {
        public CategoryService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public async Task<CategoriesModel> GetCategories(string catName, int pageNum, int pageSize)
        {

            var ret = new CategoriesModel()
            {
                RowCount=0,
                Categories=new List<CategoryShowModel>()
            };

            string key = $"Categories-{catName}-{pageNum}-{pageSize}";

            ret = await CacheService.GetAsync<CategoriesModel>(key);

            if(ret==null ||  ret.RowCount==0 || ret.Categories==null || ret.Categories.Count==0)
            {
                ret = await getCategories(catName, pageNum, pageSize);

                await CacheService.RemoveAndSetAsync(
                ret,
                key,
                TimeSpan.FromMinutes(30),
                TimeSpan.FromMinutes(5),
                Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                TokenCachClass.CatgoryToken
                );
            }

            return ret;
        }

        private async Task<CategoriesModel> getCategories(string catName, int pageNum, int pageSize)
        {
            var command = new
            {
                CategoryName = catName,
                PageNumber = pageNum,
                PageSize = pageSize
            };

            FluentResult<CategoriesModel> model =
                new FluentResult<CategoriesModel>()
                {
                    Value = new CategoriesModel()
                    {
                        RowCount = 0,
                        Categories = new List<CategoryShowModel>()
                    }
                };

            try
            {
                model = await ServiceCaller.PostDataWithValue<CategoriesModel>("Setting/Store/GetCategories", command);


                if (model == null || model.Value == null || model.IsFailed)
                {
                    throw new Exception("اطلاعات یافت نشد");
                }

            }
            catch (Exception ex)
            {
                model = new FluentResult<CategoriesModel>()
                {
                    Value = new CategoriesModel()
                    {
                        RowCount=0,
                        Categories=new List<CategoryShowModel>()
                    }
                };
                model.WithError(ex.Message);
            }

            return model.Value;
        }
    }
}
