using BehsamFramework.DapperDomain;
using LogManager.Domain.IRepositories.ILogMessageRepository;
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
    }
}
