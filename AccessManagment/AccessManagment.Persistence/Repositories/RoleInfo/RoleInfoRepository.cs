using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Persistence.Repositories.RoleInfo
{
    public class RoleInfoRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.RoleInfoTbl, int>,
        Domain.IRepositories.IRoleInfo.IRoleInfoRepository
    {
        protected internal RoleInfoRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
