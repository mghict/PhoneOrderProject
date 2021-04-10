using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Domain.IRepositories.ApplicationInfo
{
    public interface IApplicationInfoRepository :
        BehsamFramework.DapperDomain.Base.IRepository<Entities.ApplicationInfoTbl,int>
    {
    }
}
