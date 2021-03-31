using BehsamFramework.DapperDomain;
using UserManagment.Domain.IRepositories.RolesInfo;
using UserManagment.Domain.IRepositories.UserInfo;
using UserManagment.Domain.IRepositories.UsersRolesInfo;
using UserManagment.Persistence.Repositories.RolesInfo;
using UserManagment.Persistence.Repositories.UsersInfo;
using UserManagment.Persistence.Repositories.UsersRolesInfo;

namespace UserManagment.Persistence
{
    public class QueryUnitOfWork :
        BehsamFramework.DapperDomain.QueryUnitOfWork,
        IQueryUnitOfWork
    {
        private IUserInfoQueryRepository _userQueryRepository;
        private IRoleQueryRepository _roleQueryRepository;
        private IUsersRolesQueryRepository _usersRolesQueryRepository;
        public QueryUnitOfWork(Options options) : base(options)
        {
        }

        public IUserInfoQueryRepository UserQueryRepository =>
            _userQueryRepository = _userQueryRepository ?? new UsersInfoQueryRepository(IDbConnection);

        public IRoleQueryRepository RoleQueryRepository =>
            _roleQueryRepository = _roleQueryRepository ?? new RoleInfoQueryRepository(IDbConnection);

        public IUsersRolesQueryRepository UsersRolesQueryRepository =>
            _usersRolesQueryRepository = _usersRolesQueryRepository ?? new UsersRolesInfoQueryRepository(IDbConnection);
    }
}