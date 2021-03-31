using System.Data;

namespace UserAuthorize.Persistence.Repositories
{
    public class UserRoleRepository : BehsamFramework.DapperDomain.Repository<Domain.Entities.UserRoleAccessTbl, long>,
        Domain.IRepositories.Repository.IUserRoleAccessRepository
    {
        protected internal UserRoleRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
