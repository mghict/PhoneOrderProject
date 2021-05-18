namespace LogManager.Persistence
{
    public interface IUnitOfWork : BehsamFramework.DapperDomain.Base.IUnitOfWork
    {
        Domain.IRepositories.ILogMessageRepository.ILogMessageRepository LogMessageRepository { get; }
        Domain.IRepositories.IOrderLogRepository.ILogOrderRepository LogOrderRepository { get; }
    }
}
