using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace DataDapper.Repositories.UserInfo
{
    public class UserRepository : Repository<Models.UserInfoTbl, int>, IUserRepository
    {
        private const string _getPass = "Select * from UserInfoTbl where username=@UserName;";

        private const string _userAccess = "select a.* " +
                                           "from[dbo].[UserInfoTbl] a, " +
                                           "    [dbo].[UserRoleTbl] b, " +
                                           "    [dbo].PageRolePermissionTbl c, " +
                                           "    [dbo].[PermissionInfoTbl] d " +
                                           " where a.id=@id and " +
                                           "d.OperationName=@Operation and " +
                                           "d.ControllerName=@ControllerName and " +
                                           "a.ID=b.UserID and c.RoleID= b.RoleID and " +
                                           "c.PermissionID= d.id and a.Status= 2 and b.Status= 2 and c.Status= 2 and d.status= 2";
        internal UserRepository(IDbConnection idbConnection) : base(idbConnection)
        {
        }

        public Models.UserInfoTbl GetPass(string userName)
        {
            return db.QuerySingleOrDefault<Models.UserInfoTbl>(sql: _getPass, param:new {@UserName = userName});
        }

        public async Task<Models.UserInfoTbl> GetPassAsync(string userName)
        {
            return await db.QuerySingleOrDefaultAsync< Models.UserInfoTbl>(sql: _getPass, param: new { @UserName = userName });
        }

        public bool UserAccess(int userId, string Permission,string Controller)
        {
            var result= db.QuerySingleOrDefault<Models.UserInfoTbl>(sql: _userAccess, param: new { @id = userId , @Operation =Permission, @ControllerName = Controller });
            if (result == null)
                return false;

            return true;
        }

        public async Task<bool> UserAccessAsync(int userId, string Permission, string Controller)
        {
            var result =await db.QuerySingleOrDefaultAsync<Models.UserInfoTbl>(sql: _userAccess, param: new { @id = userId, @Operation = Permission, @ControllerName = Controller });
            if (result == null)
                return false;

            return true;
        }
    }
}
