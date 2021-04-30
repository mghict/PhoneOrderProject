using BehsamFramework.DapperDomain;
using BillManagement.Domain.IRepositories;

namespace BillManagement.Persistence
{
    public class QueryUnitOfWork :
        BehsamFramework.DapperDomain.QueryUnitOfWork,
        IQueryUnitOfWork
    {
        public QueryUnitOfWork(Options options) : base(options)
        {
        }


        private IOrderQueryRepository _OrderQueryRepository;
        public IOrderQueryRepository OrderQueryRepository =>
            _OrderQueryRepository = _OrderQueryRepository ?? new Repositories.OrderQueryRepository(IDbConnection);
    }
}
