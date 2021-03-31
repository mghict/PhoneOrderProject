using BehsamFramework.DapperDomain;
using UserManagment.Domain.IRepositories.RolesInfo;
using UserManagment.Domain.IRepositories.UserInfo;
using UserManagment.Domain.IRepositories.UsersRolesInfo;
using UserManagment.Persistence.Repositories.RolesInfo;
using UserManagment.Persistence.Repositories.UsersInfo;
using UserManagment.Persistence.Repositories.UsersRolesInfo;

namespace UserManagment.Persistence
{
    public class UnitOfWork : BehsamFramework.DapperDomain.UnitOfWork, IUnitOfWork
    {
        private IUserInfoRepository _userInfoRepository;
        private IRolesRepository _rolesRepository;
        private IUsersRolesRepository _usersRolesRepository;
        public UnitOfWork(Options options) : base(options)
        {
        }

        public IUserInfoRepository UserInfoRepository =>
            _userInfoRepository = _userInfoRepository ?? new UsersInfoRepository(IDbConnection);

        public IRolesRepository RolesRepository =>
            _rolesRepository = _rolesRepository ?? new RolesInfoRepository(IDbConnection);

        public IUsersRolesRepository UsersRolesRepository =>
            _usersRolesRepository = _usersRolesRepository ?? new UsersRolesInfoRepository(IDbConnection);
    }
}