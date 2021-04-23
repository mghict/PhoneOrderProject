using BehsamFramework.DapperDomain;
using LogManager.Domain.IRepositories.ILogMessageRepository;

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
    }
}
