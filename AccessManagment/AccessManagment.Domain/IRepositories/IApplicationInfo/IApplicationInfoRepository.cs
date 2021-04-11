using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Domain.IRepositories.IApplicationInfo
{
    public interface IApplicationInfoRepository :
        BehsamFramework.DapperDomain.Base.IRepository<Entities.ApplicationInfoTbl,int>
    {
    }
}
