namespace AccessManagment.Persistence
{
    public interface IQueryUnitOfWork : BehsamFramework.DapperDomain.Base.IQueryUnitOfWork
    {
        Domain.IRepositories.IApplicationInfo.IApplicationInfoQueryRepository ApplicationInfoQueryRepository { get; }
        Domain.IRepositories.IPageInfo.IPageInfoQueryRepository PageInfoQueryRepository { get; }
        Domain.IRepositories.IRoleInfo.IRoleInfoQueryRepository RoleInfoQueryRepository { get; }
        Domain.IRepositories.IRolePageAccess.IRolePageAccessQueryRepository RolePageAccessQueryRepository { get; }
    }
}

