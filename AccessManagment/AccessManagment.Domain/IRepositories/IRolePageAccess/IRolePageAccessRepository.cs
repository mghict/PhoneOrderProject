using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Domain.IRepositories.IRolePageAccess
{
    public interface IRolePageAccessRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Domain.Entities.RolePageAccess,int>
    {
        Task CreatePermision(List<Domain.Entities.RolePagesAccess> input);
    }
}
