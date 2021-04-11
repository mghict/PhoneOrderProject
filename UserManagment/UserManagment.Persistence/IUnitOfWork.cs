using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Persistence
{
    public interface IUnitOfWork:
        BehsamFramework.DapperDomain.Base.IUnitOfWork
    {
        Domain.IRepositories.ApplicationInfo.IApplicationInfoRepository ApplicationInfoRepository { get; }
    }
}
