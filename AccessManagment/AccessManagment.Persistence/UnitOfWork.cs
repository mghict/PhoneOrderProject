using AccessManagment.Domain.IRepositories.IApplicationInfo;
using AccessManagment.Domain.IRepositories.IPageInfo;
using AccessManagment.Domain.IRepositories.IRoleInfo;
using AccessManagment.Domain.IRepositories.IRolePageAccess;
using AccessManagment.Domain.IRepositories.IUser;
using AccessManagment.Domain.IRepositories.IUserRole;
using BehsamFramework.DapperDomain;

namespace AccessManagment.Persistence
{
    public class UnitOfWork : BehsamFramework.DapperDomain.UnitOfWork,IUnitOfWork
    {
        public UnitOfWork(Options options) : base(options)
        {
        }

        private IApplicationInfoRepository _applicationInfoRepository;
        public IApplicationInfoRepository ApplicationInfoRepository =>
            _applicationInfoRepository = _applicationInfoRepository ?? new Repositories.ApplicationInfo.ApplicationInfoRepository(IDbConnection);


        private IPageInfoRepository _pageInfoRepository;
        public IPageInfoRepository PageInfoRepository =>
            _pageInfoRepository = _pageInfoRepository ?? new Repositories.PageInfo.PageInfoRepository(IDbConnection);


        private IRoleInfoRepository _roleInfoRepository;
        public IRoleInfoRepository RoleInfoRepository =>
            _roleInfoRepository = _roleInfoRepository ?? new Repositories.RoleInfo.RoleInfoRepository(IDbConnection);


        private IRolePageAccessRepository _rolePageAccessRepository;
        public IRolePageAccessRepository RolePageAccessRepository =>
            _rolePageAccessRepository = _rolePageAccessRepository ?? new Repositories.RoleAccessPage.RolePageAccessRepository(IDbConnection);

        private IUserRepository _userRepository;
        public IUserRepository UserRepository =>
            _userRepository = _userRepository ?? new Repositories.UserInfo.UserRepository(IDbConnection);


        private IUserRoleRepository _userRoleRepository;
        public IUserRoleRepository UserRoleRepository =>
            _userRoleRepository = _userRoleRepository ?? new Repositories.UserRole.UserRoleRepository(IDbConnection);
    }
}

