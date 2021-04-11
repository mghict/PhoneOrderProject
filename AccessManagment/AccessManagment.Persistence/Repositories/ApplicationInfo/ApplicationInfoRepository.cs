using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Persistence.Repositories.ApplicationInfo
{
    public class ApplicationInfoRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.ApplicationInfoTbl, int>,
        Domain.IRepositories.IApplicationInfo.IApplicationInfoRepository
    {
        protected internal ApplicationInfoRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
