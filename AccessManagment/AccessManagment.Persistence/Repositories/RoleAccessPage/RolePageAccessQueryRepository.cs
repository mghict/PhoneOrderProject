using AccessManagment.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace AccessManagment.Persistence.Repositories.RoleAccessPage
{
    public class RolePageAccessQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.RolePageAccess, int>,
        Domain.IRepositories.IRolePageAccess.IRolePageAccessQueryRepository
    {
        protected internal RolePageAccessQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<List<PageInfoTbl>> GetPageByRoleAsync(int roleId)
        {
            var query = "Select a.* from PageInfoTbl a,RolePageAccess b where a.Id=b.PageId and b.RoleId=@roleId and b.Status=1";
            var param = new
            {
                @roleId = roleId
            };

            var lst = await db.QueryAsync<PageInfoTbl>(query, param);

            return lst.ToList();
        }

        public async Task<List<RoleInfoTbl>> GetRoleByPageAsync(int pageId)
        {
            var query = "Select a.* from RoleInfoTbl a,RolePageAccess b where a.Id=b.RoleId and b.PageId=@pageId and b.Status=1";
            var param = new
            {
                @pageId = pageId
            };

            var lst = await db.QueryAsync<RoleInfoTbl>(query, param);

            return lst.ToList();
        }

        public async Task<List<RolePagesAccess>> GetRolePermisions(int roleId)
        {
            var query = "exec [dbo].[RolePermisions]  @RoleId";
            var param = new
            {
                @RoleId = roleId
            };

            var lst = await db.QueryAsync<RolePagesAccess>(query, param);

            return lst.ToList();
        }
    }
}
