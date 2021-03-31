using System.Data;

namespace UserAuthorize.Persistence.QueryRepositories
{
    public class UserRoleQueryRepository : BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.UserRoleAccessTbl, long>,
       Domain.IRepositories.QueryRepository.IUserRoleAccessQueryRepository
    {
        protected internal UserRoleQueryRepository(IDbConnection _db) : base(_db)
        {
        }
    }

}
