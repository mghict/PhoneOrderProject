using AccessManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace AccessManagment.Persistence.Repositories.UserRole
{
    public class UserRoleRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.UserRoleAccessTbl, long>,
        Domain.IRepositories.IUserRole.IUserRoleRepository
    {
        protected internal UserRoleRepository(IDbConnection _db) : base(_db)
        {
        }
    }

    public class UserRoleQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.UserRoleAccessTbl, long>,
        Domain.IRepositories.IUserRole.IUserRoleQueryRepository
    {
        protected internal UserRoleQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<List<UserRoleAccessTbl>> GetAllByRoleId(int roleId)
        {
            var query = "exec [dbo].[GetUsersAccess] @UserId,@RoleId";
            var param = new
            {
                @UserId = 0,
                @RoleId = roleId
            };

            var lst = await db.QueryAsync<UserRoleAccessTbl>(query, param);
            return lst.ToList();
        }

        public async Task<List<UserRoleAccessTbl>> GetAllByUserId(int userId)
        {
            var query = "exec [dbo].[GetUsersAccess] @UserId,@RoleId";
            var param = new
            {
                @UserId = userId,
                @RoleId = 0
            };

            var lst = await db.QueryAsync<UserRoleAccessTbl>(query, param);
            return lst.ToList();
        }
    }
}
