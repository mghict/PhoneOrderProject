using System.Data;

namespace DataDapper.Repositories.RoleInfo
{
    public class RoleRepository : Repository<Models.RoleInfoTbl, int>, IRoleRepository
    {
        internal RoleRepository(IDbConnection idbConnection) : base(idbConnection)
        {
        }
    }
}
