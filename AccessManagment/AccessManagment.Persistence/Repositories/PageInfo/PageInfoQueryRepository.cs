using AccessManagment.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace AccessManagment.Persistence.Repositories.PageInfo
{
    public class PageInfoQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.PageInfoTbl, int>,
        Domain.IRepositories.IPageInfo.IPageInfoQueryRepository
    {
        protected internal PageInfoQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<List<PageInfoTbl>> GetByApplicationId(int appId)
        {
            var query = "Select * from dbo.PageInfoTbl where ApplicationId=@ApplicationId";
            var param = new
            {
                @ApplicationId = appId
            };

            var lst = await db.QueryAsync<PageInfoTbl>(query, param);

            return lst.ToList();
        }

        public async Task<List<PageInfoTbl>> GetByParentId(int parentId)
        {
            var query = "Select * from dbo.PageInfoTbl where ParentId=@ParentId";
            var param = new
            {
                @ParentId = parentId
            };

            var lst = await db.QueryAsync<PageInfoTbl>(query, param);

            return lst.ToList();
        }
    }
}
