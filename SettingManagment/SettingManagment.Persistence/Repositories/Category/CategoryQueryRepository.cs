using BehsamFramework.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib;

namespace SettingManagment.Persistence.Repositories.Category
{
    public class CategoryQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.CategoryInfoTbl, float>,
        Domain.IRepositories.Category.ICategoryQueryRepository
    {
        protected internal CategoryQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<CategoriesModel> GetCategoryAllAsync(string catName = "", int pageNumber = 0, int pageSize = 20)
        {
            var param =
                new
                {
                    @CatName = catName,
                    @PageNumber = pageNumber,
                    @PageSize = pageSize
                };

            var query = "exec [dbo].[GetCategories] @CatName,@PageNumber,@PageSize";

            var model = new CategoriesModel()
            {
                RowCount = 0,
                Categories = new List<CategoryShowModel>()
            };
            try
            {
                using (var lst = await db.QueryMultipleAsync(query, param))
                {
                    model.RowCount = lst.ReadFirst<long>();
                    var temp = lst.Read<CategoryShowModel>().ToList();
                    model.Categories.AddRange(temp);
                }
            }
            catch (Exception ex)
            {
                model = new CategoriesModel()
                {
                    RowCount = 0,
                    Categories = new List<CategoryShowModel>()
                };
            }

            return model;
        }

        public async Task<List<CategoryShowModel>> GetCategoryByParentAsync(float id)
        {
            var queryParent = "select * FROM [dbo].[CategoryInfoTbl] where(ParentID = 0 or ParentID is null) and id> 0";
            var queryChild= "select * FROM [dbo].[CategoryInfoTbl] where(ParentID = @id) and id> 0";

            string query = queryParent;

            if(id>0)
            {
                query = queryChild;

                var param = new
                {
                    @id = id
                };
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Decimal);

                var entityChild = await db.QueryAsync<CategoryShowModel>(query, parameters);

                return entityChild.ToList();
            }

            var entities =await db.QueryAsync<CategoryShowModel>(query);

            return entities.ToList();
        }
    }
}
