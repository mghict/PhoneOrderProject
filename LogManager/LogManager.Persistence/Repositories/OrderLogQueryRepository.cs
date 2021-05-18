using System.Data;

namespace LogManager.Persistence.Repositories
{
    public class OrderLogQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<BehsamFramework.Models.OrderLogsModel, long>,
        Domain.IRepositories.IOrderLogRepository.ILogOrderQueryRepository
    {
        protected internal OrderLogQueryRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
