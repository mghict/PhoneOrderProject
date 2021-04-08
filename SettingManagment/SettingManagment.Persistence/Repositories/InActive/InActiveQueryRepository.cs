using System.Data;

namespace SettingManagment.Persistence.Repositories.InActive
{
    public class InActiveQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.InActiveTbl, int>,
        Domain.IRepositories.InActive.IInActiveQueryRepository
    {
        protected internal InActiveQueryRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
