using System.Data;

namespace UserAuthorize.Persistence.QueryRepositories
{
    public class ApplicationQueryRepository : BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.ApplicationInfoTbl, int>,
       Domain.IRepositories.QueryRepository.IApplicationQueryRepository
    {
        protected internal ApplicationQueryRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
