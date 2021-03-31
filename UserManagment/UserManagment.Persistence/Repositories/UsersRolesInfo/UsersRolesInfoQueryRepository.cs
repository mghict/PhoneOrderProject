using System.Data;

namespace UserManagment.Persistence.Repositories.UsersRolesInfo
{
    public class UsersRolesInfoQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.UserRoleTbl, int>,
        Domain.IRepositories.UsersRolesInfo.IUsersRolesQueryRepository
    {
        protected internal UsersRolesInfoQueryRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}