using System.Data;

namespace DataDapper.Repositories.UserRole
{
    public class UserRoleRepository : Repository<Models.UserRoleTbl, int>, IUserRoleRepository
    {
        internal UserRoleRepository(IDbConnection idbConnection) : base(idbConnection)
        {
        }
    }
}
