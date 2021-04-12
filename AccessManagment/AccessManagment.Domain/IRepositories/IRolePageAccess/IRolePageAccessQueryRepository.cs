using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace AccessManagment.Domain.IRepositories.IRolePageAccess
{
    public interface IRolePageAccessQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Domain.Entities.RolePageAccess, int>
    {
        Task<List<Domain.Entities.PageInfoTbl>> GetPageByRoleAsync(int roleId);

        Task<List<Domain.Entities.RoleInfoTbl>> GetRoleByPageAsync(int pageId);

        Task<List<Domain.Entities.RolePagesAccess>> GetRolePermisions(int roleId);

    }
}
