using System.Data;

namespace UserAuthorize.Persistence.Repositories
{
    public class ApplicationRepository : BehsamFramework.DapperDomain.Repository<Domain.Entities.ApplicationInfoTbl, int>,
        Domain.IRepositories.Repository.IApplicationInfoRepository
    {
        protected internal ApplicationRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
