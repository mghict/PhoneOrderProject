using BehsamFramework.DapperDomain;
using LogManager.Domain.IRepositories.ILogMessageRepository;
using LogManager.Domain.IRepositories.IOrderLogRepository;

namespace LogManager.Persistence
{
    public class UnitOfWork :
        BehsamFramework.DapperDomain.UnitOfWork,
        IUnitOfWork
    {
        public UnitOfWork(Options options) : base(options)
        {
        }

        private ILogMessageRepository _LogMessageRepository;
        public ILogMessageRepository LogMessageRepository =>
            _LogMessageRepository = _LogMessageRepository ?? new Repositories.LogMessageRepository(IDbConnection);


        private ILogOrderRepository _LogOrderRepository;
        public ILogOrderRepository LogOrderRepository =>
            _LogOrderRepository = _LogOrderRepository ?? new Repositories.OrderLogRepository(IDbConnection);
    }
}
