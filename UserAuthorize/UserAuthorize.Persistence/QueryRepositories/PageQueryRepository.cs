using System.Data;

namespace UserAuthorize.Persistence.QueryRepositories
{
    public class PageQueryRepository : BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.PageInfoTbl, int>,
       Domain.IRepositories.QueryRepository.IPageQueryRepository
    {
        protected internal PageQueryRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
