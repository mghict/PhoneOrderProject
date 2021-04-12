using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Persistence
{
    public interface IUnitOfWork:BehsamFramework.DapperDomain.Base.IUnitOfWork
    {
        Domain.IRepositories.IApplicationInfo.IApplicationInfoRepository ApplicationInfoRepository { get; }
        Domain.IRepositories.IPageInfo.IPageInfoRepository PageInfoRepository { get; }
        Domain.IRepositories.IRoleInfo.IRoleInfoRepository RoleInfoRepository { get; }
        Domain.IRepositories.IRolePageAccess.IRolePageAccessRepository RolePageAccessRepository { get; }
    }
}

