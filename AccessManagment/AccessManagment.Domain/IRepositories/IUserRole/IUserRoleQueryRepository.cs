using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessManagment.Domain.IRepositories.IUserRole
{
    public interface IUserRoleQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Domain.Entities.UserRoleAccessTbl, long>
    {
        Task<List<Domain.Entities.UserRoleAccessTbl>> GetAllByUserId(int userId);
        Task<List<Domain.Entities.UserRoleAccessTbl>> GetAllByRoleId(int roleId);
    }
}
