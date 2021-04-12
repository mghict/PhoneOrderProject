using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessManagment.Domain.IRepositories.IRoleInfo
{
    public interface IRoleInfoQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Domain.Entities.RoleInfoTbl, int>
    {
        Task<List<Domain.Entities.RoleInfoTbl>> GetByApplication(int appId);
    }
}
