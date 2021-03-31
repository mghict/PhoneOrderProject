using System.Data;

namespace UserAuthorize.Persistence.Repositories
{
    public class RoleRepository : BehsamFramework.DapperDomain.Repository<Domain.Entities.RoleInfoTbl, int>,
        Domain.IRepositories.Repository.IRoleInfoRepository
    {
        protected internal RoleRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
