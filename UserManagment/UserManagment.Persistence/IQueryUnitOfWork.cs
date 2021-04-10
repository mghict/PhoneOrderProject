using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Persistence
{
    public interface IQueryUnitOfWork : BehsamFramework.DapperDomain.Base.IQueryUnitOfWork
    {
        Domain.IRepositories.UserInfo.IUserInfoQueryRepository UserQueryRepository { get; }
        Domain.IRepositories.RolesInfo.IRoleQueryRepository RoleQueryRepository { get; }
        Domain.IRepositories.UsersRolesInfo.IUsersRolesQueryRepository UsersRolesQueryRepository { get; }
        Domain.IRepositories.ApplicationInfo.IApplicationInfoQueryRepository ApplicationInfoQueryRepository { get; }
    }
}
