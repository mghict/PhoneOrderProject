using BehsamFramework.DapperDomain;
using LogManager.Domain.IRepositories.ILogMessageRepository;
using LogManager.Domain.IRepositories.IOrderLogRepository;
using System;

namespace LogManager.Persistence
{
    public class QueryUnitOfWork :
        BehsamFramework.DapperDomain.QueryUnitOfWork,
        IQueryUnitOfWork
    {
        public QueryUnitOfWork(Options options) : base(options)
        {
        }

        private ILogMessageQueryRepository _LogMessageQueryRepository;
        public ILogMessageQueryRepository LogMessageQueryRepository =>
            _LogMessageQueryRepository = _LogMessageQueryRepository ?? new Repositories.LogMessageQueryRepository(IDbConnection);

        private ILogOrderQueryRepository _LogOrderQueryRepository;
        public ILogOrderQueryRepository LogOrderQueryRepository =>
            _LogOrderQueryRepository = _LogOrderQueryRepository ?? new Repositories.OrderLogQueryRepository(IDbConnection);
    }
}
