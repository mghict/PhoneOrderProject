using System.Data;

namespace UserAuthorize.Persistence.Repositories
{
    public class RolePageRepository : BehsamFramework.DapperDomain.Repository<Domain.Entities.RolePageAccess, long>,
        Domain.IRepositories.Repository.IRolePageAccessRepository
    {
        protected internal RolePageRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
