using AccessManagment.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace AccessManagment.Persistence.Repositories.RoleInfo
{
    public class RoleInfoQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.RoleInfoTbl, int>,
        Domain.IRepositories.IRoleInfo.IRoleInfoQueryRepository
    {
        protected internal RoleInfoQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<List<RoleInfoTbl>> GetByApplication(int appId)
        {
            var query = "Select * from RoleInfoTbl where ApplicationId=@ApplicationId";
            var param = new
            {
                @ApplicationId = appId
            };

            var lst = await db.QueryAsync<RoleInfoTbl>(query, param);

            return lst.ToList();
        }
    }
}
