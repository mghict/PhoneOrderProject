using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace AccessManagment.Persistence.Repositories.UserActive
{
    public class UserActiveRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.UserActiveInfo, long>,
        Domain.IRepositories.IUserActive.IUserActiveRepository
    {
        protected internal UserActiveRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<bool> UpdateStatusAsync(int userId, int status, DateTime createDate)
        {
            var query = "update dbo.UserActiveInfo set Status=@Status where UserId=@UserId and CreateDate=cast(@CreateDate as date)";
            var param = new
            {
                @Status = status,
                @UserId = userId,
                @CreateDate = createDate
            };

            try
            {
                var reslut = await db.ExecuteAsync(query, param);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
