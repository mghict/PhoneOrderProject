using BehsamFramework.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace UserAuthorize.Persistence.QueryRepositories
{
    public class UserQueryRepository : BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.UserInfoTbl, int>,
       Domain.IRepositories.QueryRepository.IUserQueryRepository
    {
        protected internal UserQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<bool> UserAccessAsync(int userId, string accessName, int applicationId)
        {
            var query = "exec UserAccess  @UserId,@AccessName,@ApplicationId";
            var param = new
            {
                @UserId = userId,
                AccessName = accessName,
                @ApplicationId = applicationId
            };
            try
            {
                var entity = await db.QueryFirstOrDefaultAsync(query, param, commandType: CommandType.StoredProcedure);
                
                if (entity == null || entity<1)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
            

        }

        public async Task<Domain.Entities.UserInfoTbl> UserLoginAsync(long userName, string password, int applicationId)
        {
            var query = "exec LoginUser @UserName,@Password,@ApplicationId";
            
            var param = new
            {
                @UserName = userName,
                @Password = password,
                @ApplicationId = applicationId
            };

            var entity = await db.QueryFirstOrDefaultAsync<Domain.Entities.UserInfoTbl>(query, param,commandType: CommandType.StoredProcedure);
            if(entity!=null)
            {
                entity.Password = "";
            }

            return entity;
        }
    }
}
