using System.Data;

namespace UserManagment.Persistence.Repositories.RolesInfo
{
    public class RoleInfoQueryRepository:
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.RoleInfoTbl,int>,
        Domain.IRepositories.RolesInfo.IRoleQueryRepository
    {
        protected internal RoleInfoQueryRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}