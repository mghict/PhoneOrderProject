using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Domain.IRepositories.RolesInfo
{
    public interface IRoleQueryRepository:BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.RoleInfoTbl,int>
    {
    }
}
