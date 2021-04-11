using System.Data;

namespace AccessManagment.Persistence.Repositories.ApplicationInfo
{
    public class ApplicationInfoQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.ApplicationInfoTbl, int>,
        Domain.IRepositories.IApplicationInfo.IApplicationInfoQueryRepository
    {
        protected internal ApplicationInfoQueryRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
