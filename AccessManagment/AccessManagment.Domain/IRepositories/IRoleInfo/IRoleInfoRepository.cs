using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Domain.IRepositories.IRoleInfo
{
    public interface IRoleInfoRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Domain.Entities.RoleInfoTbl,int>
    {
    }
}
