using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Persistence
{
    public interface IUnitOfWork: BehsamFramework.DapperDomain.Base.IUnitOfWork
    {
        Domain.IRepositories.UserInfo.IUserInfoRepository UserInfoRepository { get; }
        Domain.IRepositories.RolesInfo.IRolesRepository RolesRepository { get; }
        Domain.IRepositories.UsersRolesInfo.IUsersRolesRepository UsersRolesRepository { get;}
        Domain.IRepositories.ApplicationInfo.IApplicationInfoRepository ApplicationInfoRepository { get; }
    }
}
