using System.Data;

namespace LogManager.Persistence.Repositories
{
    public class LogMessageQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.LogMessage, long>,
        Domain.IRepositories.ILogMessageRepository.ILogMessageQueryRepository
    {
        protected internal LogMessageQueryRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
