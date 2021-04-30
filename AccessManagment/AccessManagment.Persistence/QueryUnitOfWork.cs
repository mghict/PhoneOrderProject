using AccessManagment.Domain.IRepositories.IApplicationInfo;
using AccessManagment.Domain.IRepositories.IPageInfo;
using AccessManagment.Domain.IRepositories.IRoleInfo;
using AccessManagment.Domain.IRepositories.IRolePageAccess;
using AccessManagment.Domain.IRepositories.IUser;
using AccessManagment.Domain.IRepositories.IUserActive;
using AccessManagment.Domain.IRepositories.IUserRole;
using BehsamFramework.DapperDomain;

namespace AccessManagment.Persistence
{
    public class QueryUnitOfWork : BehsamFramework.DapperDomain.QueryUnitOfWork, IQueryUnitOfWork
    {
        public QueryUnitOfWork(Options options) : base(options)
        {
        }

        private IApplicationInfoQueryRepository _applicationInfoQueryRepository;
        public IApplicationInfoQueryRepository ApplicationInfoQueryRepository =>
            _applicationInfoQueryRepository = _applicationInfoQueryRepository ?? new Repositories.ApplicationInfo.ApplicationInfoQueryRepository(IDbConnection);

        private IPageInfoQueryRepository _pageInfoQueryRepository;
        public IPageInfoQueryRepository PageInfoQueryRepository =>
            _pageInfoQueryRepository = _pageInfoQueryRepository ?? new Repositories.PageInfo.PageInfoQueryRepository(IDbConnection);


        private IRoleInfoQueryRepository _roleInfoQueryRepository;
        public IRoleInfoQueryRepository RoleInfoQueryRepository =>
            _roleInfoQueryRepository = _roleInfoQueryRepository ?? new Repositories.RoleInfo.RoleInfoQueryRepository(IDbConnection);


        private IRolePageAccessQueryRepository _rolePageAccessQueryRepository;
        public IRolePageAccessQueryRepository RolePageAccessQueryRepository =>
            _rolePageAccessQueryRepository = _rolePageAccessQueryRepository ?? new Repositories.RoleAccessPage.RolePageAccessQueryRepository(IDbConnection);


        private IUserQueryRepository _userQueryRepository;
        public IUserQueryRepository UserQueryRepository =>
            _userQueryRepository = _userQueryRepository ?? new Repositories.UserInfo.UserQueryRepository(IDbConnection);


        private IUserRoleQueryRepository _userRoleQueryRepository;
        public IUserRoleQueryRepository UserRoleQueryRepository =>
            _userRoleQueryRepository= _userRoleQueryRepository ?? new Repositories.UserRole.UserRoleQueryRepository(IDbConnection);


        private IUserActiveQueryRepository _UserActiveQueryRepository;
        public IUserActiveQueryRepository UserActiveQueryRepository =>
            _UserActiveQueryRepository= _UserActiveQueryRepository ?? new Repositories.UserActive.UserActiveQueryRepository(IDbConnection);
    }
}

