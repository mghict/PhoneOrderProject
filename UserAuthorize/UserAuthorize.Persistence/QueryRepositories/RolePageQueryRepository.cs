using System.Data;

namespace UserAuthorize.Persistence.QueryRepositories
{
    public class RolePageQueryRepository : BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.RolePageAccess, long>,
       Domain.IRepositories.QueryRepository.IRolePageAccessQueryRepository
    {
        protected internal RolePageQueryRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
