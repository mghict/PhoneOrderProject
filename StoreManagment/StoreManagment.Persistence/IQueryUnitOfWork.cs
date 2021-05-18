namespace StoreManagment.Persistence
{
    public interface IQueryUnitOfWork :
        BehsamFramework.DapperDomain.Base.IQueryUnitOfWork
    {
        Domain.IQueryRepositories.IOrderInfoQueryRepository OrderInfoQueryRepository { get; }
        Domain.IQueryRepositories.IOrderItemsQueryRepository OrderItemsQueryRepository { get; }
        Domain.IQueryRepositories.IOrderDetailQueryRepository OrderDetailQueryRepository { get; }
        Domain.IQueryRepositories.IOrderUserActiveQueryRepository UserActiveQueryRepository { get; }
        Domain.IQueryRepositories.IOrderItemsReserveRepository OrderItemsReserveRepository { get; }
    }
}
