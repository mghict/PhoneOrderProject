using BehsamFramework.DapperDomain;
using UserAuthorize.Domain.IRepositories.Repository;

namespace UserAuthorize.Persistence
{
    public class UnitOfWork :
        BehsamFramework.DapperDomain.UnitOfWork,
        IUnitOfWork
    {
        public UnitOfWork(Options options) : base(options)
        {
        }

        private IUserInfoRepository userInfoRepository;
        public IUserInfoRepository UserInfoRepository =>
            userInfoRepository = userInfoRepository ?? new Persistence.Repositories.UserRepository(IDbConnection);
        //----------------------------------------------------------------------------

        private IRoleInfoRepository roleInfoRepository;
        public IRoleInfoRepository RoleInfoRepository =>
            roleInfoRepository = roleInfoRepository ?? new Persistence.Repositories.RoleRepository(IDbConnection);
        //----------------------------------------------------------------------------
        private IApplicationInfoRepository applicationInfoRepository;
        public IApplicationInfoRepository ApplicationInfoRepository =>
            applicationInfoRepository = applicationInfoRepository ?? new Persistence.Repositories.ApplicationRepository(IDbConnection);
        //----------------------------------------------------------------------------
        private IPageInfoRepository pageInfoRepository;
        public IPageInfoRepository PageInfoRepository =>
            pageInfoRepository = pageInfoRepository ?? new Persistence.Repositories.PageRepository(IDbConnection);
        //----------------------------------------------------------------------------
        private IUserRoleAccessRepository userRoleAccessRepository;
        public IUserRoleAccessRepository UserRoleAccessRepository =>
            userRoleAccessRepository = userRoleAccessRepository ?? new Persistence.Repositories.UserRoleRepository(IDbConnection);
        //----------------------------------------------------------------------------
        private IRolePageAccessRepository rolePageAccessRepository;
        public IRolePageAccessRepository RolePageAccessRepository =>
            rolePageAccessRepository = rolePageAccessRepository ?? new Persistence.Repositories.RolePageRepository(IDbConnection);
        //----------------------------------------------------------------------------
    }
}
