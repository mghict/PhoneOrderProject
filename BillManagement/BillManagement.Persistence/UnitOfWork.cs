using BehsamFramework.DapperDomain;
using BillManagement.Domain.IRepositories;

namespace BillManagement.Persistence
{
    public class UnitOfWork :
        BehsamFramework.DapperDomain.UnitOfWork,
        IUnitOfWork
    {
        public UnitOfWork(Options options) : base(options)
        {
        }


        private IOrderRepository _OrderRepository;
        public IOrderRepository OrderRepository =>
            _OrderRepository = _OrderRepository ?? new Repositories.OrderRepository(IDbConnection);
    }
}
