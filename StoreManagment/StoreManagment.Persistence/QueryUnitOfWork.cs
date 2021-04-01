﻿using BehsamFramework.DapperDomain;
using StoreManagment.Domain.IQueryRepositories;

namespace StoreManagment.Persistence
{
    public class QueryUnitOfWork :
        BehsamFramework.DapperDomain.QueryUnitOfWork,
        IQueryUnitOfWork
    {
        public QueryUnitOfWork(Options options) : base(options)
        {
        }

        private IOrderInfoQueryRepository _OrderInfoQueryRepository;
        public IOrderInfoQueryRepository OrderInfoQueryRepository =>
            _OrderInfoQueryRepository = _OrderInfoQueryRepository ?? new QueryRepositories.OrderInfoQueryRepository(IDbConnection);
        //--------------------------------------------------------

        private IOrderItemsQueryRepository _OrderItemsQueryRepository;
        public IOrderItemsQueryRepository OrderItemsQueryRepository =>
            _OrderItemsQueryRepository = _OrderItemsQueryRepository ?? new QueryRepositories.OrderItemsQueryRepository(IDbConnection);

        //--------------------------------------------------------
        private IOrderDetailQueryRepository _OrderDetailQueryRepository;
        public IOrderDetailQueryRepository OrderDetailQueryRepository =>
            _OrderDetailQueryRepository = _OrderDetailQueryRepository ?? new QueryRepositories.OrderDetailQueryRepository(IDbConnection);
    }
}
