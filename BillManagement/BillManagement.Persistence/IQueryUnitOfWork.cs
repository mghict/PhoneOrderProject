namespace BillManagement.Persistence
{
    public interface IQueryUnitOfWork :
        BehsamFramework.DapperDomain.Base.IQueryUnitOfWork
    {
        Domain.IRepositories.IOrderQueryRepository OrderQueryRepository { get; }
    }
}
