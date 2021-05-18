namespace LogManager.Domain.IRepositories.IOrderLogRepository
{
    public interface ILogOrderQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<BehsamFramework.Models.OrderLogsModel, long>
    {
    }
}
