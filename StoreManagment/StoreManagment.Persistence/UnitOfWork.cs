using BehsamFramework.DapperDomain;
using StoreManagment.Domain.IRepositories;

namespace StoreManagment.Persistence
{
    public class UnitOfWork :
        BehsamFramework.DapperDomain.UnitOfWork,
        IUnitOfWork
    {
        public UnitOfWork(Options options) : base(options)
        {
        }

        private IOrderInfoRepository _OrderInfoRepository;
        public IOrderInfoRepository OrderInfoRepository =>
            _OrderInfoRepository = _OrderInfoRepository ?? new Repositories.OrderInfoRepository(IDbConnection);
        //-----------------------------------------

        private IOrderItemsRepository _OrderItemsRepository;
        public IOrderItemsRepository OrderItemsRepository =>
            _OrderItemsRepository = _OrderItemsRepository ?? new Repositories.OrderItemsRepository(IDbConnection);
        //-----------------------------------------

        private IOrderDetailRepository _OrderDetailRepository;
        public IOrderDetailRepository OrderDetailRepository =>
            _OrderDetailRepository = _OrderDetailRepository ?? new Repositories.OrderDetailRepository(IDbConnection);

        private IOrderUserActiveRepository _UserActiveRepository;
        public IOrderUserActiveRepository UserActiveRepository =>
            _UserActiveRepository = _UserActiveRepository ?? new Repositories.OrderUserActivityRepository(IDbConnection);
    }
}
