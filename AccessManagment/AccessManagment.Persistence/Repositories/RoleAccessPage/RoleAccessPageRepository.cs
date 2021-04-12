using AccessManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperParameters;

namespace AccessManagment.Persistence.Repositories.RoleAccessPage
{
    public class RolePageAccessRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.RolePageAccess, int>,
        Domain.IRepositories.IRolePageAccess.IRolePageAccessRepository
    {
        protected internal RolePageAccessRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task CreatePermision(List<RolePagesAccess> input)
        {
            var query = "exec [dbo].[RolePermisions_Insert] @tbl ";

            var lst = input.Select(s => new
            {
                RoleId = s.RoleId,
                PageId = s.PageId,
                IsAccess = (s.IsAccess?1:0)
            }).ToList();

            var param = new DynamicParameters();
            
            param.AddTable("@tbl", "RolePermisionDto", lst);

            var resp =await db.ExecuteAsync(query, param);

            return;
        }
    }
}
