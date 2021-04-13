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
            db.Open();

            var isoLevel = System.Data.IsolationLevel.Serializable;
            using (var transaction = db.BeginTransaction(isoLevel))
            {
                try
                {
                    var query = "exec [dbo].[RolePermisions_Insert_element] @PageId,@RoleId,@Status ";

                    var lst = input.Select(s => new
                    {
                        RoleId = s.RoleId,
                        PageId = s.PageId,
                        Status = (s.IsAccess ? 1 : 0)
                    }).ToList();


                    foreach (var item in lst)
                    {
                        var resp = await db.ExecuteAsync(query, item,transaction: transaction);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("عدم امکان درج اطلاعات");
                }

            }

            return;
        }
    }
}
