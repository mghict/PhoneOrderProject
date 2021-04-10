using System.Data;

namespace UserManagment.Persistence.Repositories.ApplicationInfo
{
    public class ApplicationInfoQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.ApplicationInfoTbl, int>,
        Domain.IRepositories.ApplicationInfo.IApplicationInfoQueryRepository
    {
        protected internal ApplicationInfoQueryRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
