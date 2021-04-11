namespace AccessManagment.Persistence
{
    public interface IQueryUnitOfWork : BehsamFramework.DapperDomain.Base.IQueryUnitOfWork
    {
        Domain.IRepositories.IApplicationInfo.IApplicationInfoQueryRepository ApplicationInfoQueryRepository { get; }
        Domain.IRepositories.IPageInfo.IPageInfoQueryRepository PageInfoQueryRepository { get; }
    }
}

