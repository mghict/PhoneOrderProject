namespace UserAuthorize.Persistence
{
    public interface IUnitOfWork :
        BehsamFramework.DapperDomain.Base.IUnitOfWork
    {
        Domain.IRepositories.Repository.IUserInfoRepository UserInfoRepository { get; }
        Domain.IRepositories.Repository.IRoleInfoRepository RoleInfoRepository { get; }
        Domain.IRepositories.Repository.IApplicationInfoRepository ApplicationInfoRepository { get; }
        Domain.IRepositories.Repository.IPageInfoRepository PageInfoRepository { get; }
        Domain.IRepositories.Repository.IUserRoleAccessRepository UserRoleAccessRepository { get; }
        Domain.IRepositories.Repository.IRolePageAccessRepository RolePageAccessRepository { get; }
    }
}
