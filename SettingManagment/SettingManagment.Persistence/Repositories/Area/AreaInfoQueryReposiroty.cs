using SettingManagment.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace SettingManagment.Persistence.Repositories.Area
{
    public class AreaInfoQueryReposiroty :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.AreaInfoTbl, int>,
        Domain.IRepositories.Area.IAreaInfoQueryRepository
    {
        protected internal AreaInfoQueryReposiroty(IDbConnection _db) : base(_db)
        {
        }

        public async Task<AreaModel> GetAllSearch(string searchKey = "", int pageNumber = 0, int pageSize = 20)
        {
            var param =
                new
                {
                    @Name = searchKey,
                    @PageNumber = pageNumber,
                    @PageSize = pageSize
                };

            var query = "exec [dbo].[GetAreaInfo] @Name,@PageNumber,@PageSize";

            var model = new AreaModel()
            {
                RowCount = 0,
                Areas = new List<AreaInfoTbl>()
            };

            using (var lst = await db.QueryMultipleAsync(query, param))
            {
                model.RowCount = lst.ReadFirst<long>();
                var temp = lst.Read<AreaInfoTbl>().ToList();
                model.Areas.AddRange(temp);
            }

            return model;
        }

        public async Task<List<Domain.Entities.AttributeStatus>> GetAreaType()
        {
            var query = "select * from AttributeStatusTbl where upper(Trim(Subject))='AREATYPE'";

            var lst = await db.QueryAsync<Domain.Entities.AttributeStatus>(query);

            return lst.ToList();
        }

        public async Task<List<AreaInfoTbl>> GetByCityId(int cityId, int areaType)
        {
            var query = "exec GetAreaInfoByCityOrParentAndType @ParentId,@CityId,@Type";

            var param = new
            {
                @ParentId = 0,
                @CityId = cityId,
                @Type = areaType
            };

            var lst = await db.QueryAsync<AreaInfoTbl>(query, param);

            return lst.ToList();

        }

        public override AreaInfoTbl GetById(int id)
        {
            var query = "exec dbo.GetAreaInfoById @id";

            var param = new
            {
                @id = id
            };

            var lst = db.QueryFirst<AreaInfoTbl>(query, param);

            return lst;
        }

        public override async Task<AreaInfoTbl> GetByIdAsync(int id)
        {
            var query = "exec dbo.GetAreaInfoById @id";

            var param = new
            {
                @id=id
            };

            var lst = await db.QueryFirstAsync<AreaInfoTbl>(query, param);

            return lst;
        }

        public async Task<List<AreaInfoTbl>> GetByParentId(int parentId, int areaType)
        {
            var query = "exec GetAreaInfoByCityOrParentAndType @ParentId,@CityId,@Type";

            var param = new
            {
                @ParentId = parentId,
                @CityId = 0,
                @Type = areaType
            };

            var lst = await db.QueryAsync<AreaInfoTbl>(query, param);

            return lst.ToList();
        }


    }
}
