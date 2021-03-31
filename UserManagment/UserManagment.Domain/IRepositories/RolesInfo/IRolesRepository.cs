using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Domain.IRepositories.RolesInfo
{
    public interface IRolesRepository:BehsamFramework.DapperDomain.Base.IRepository<Entities.RoleInfoTbl,int>
    {
    }
}
