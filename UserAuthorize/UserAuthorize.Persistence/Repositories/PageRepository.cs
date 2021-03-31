using System.Data;

namespace UserAuthorize.Persistence.Repositories
{
    public class PageRepository : BehsamFramework.DapperDomain.Repository<Domain.Entities.PageInfoTbl, int>,
       Domain.IRepositories.Repository.IPageInfoRepository
    {
        protected internal PageRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
