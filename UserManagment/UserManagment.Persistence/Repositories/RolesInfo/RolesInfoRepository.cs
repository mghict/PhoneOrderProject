using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Persistence.Repositories.RolesInfo
{
    public class RolesInfoRepository:
        BehsamFramework.DapperDomain.Repository<Domain.Entities.RoleInfoTbl,int>,
        Domain.IRepositories.RolesInfo.IRolesRepository
    {
        protected internal RolesInfoRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
