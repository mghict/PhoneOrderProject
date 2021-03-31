using System.Data;

namespace UserAuthorize.Persistence.QueryRepositories
{
    public class RoleQueryRepository : BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.RoleInfoTbl, int>,
       Domain.IRepositories.QueryRepository.IRoleQueryRepository
    {
        protected internal RoleQueryRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
