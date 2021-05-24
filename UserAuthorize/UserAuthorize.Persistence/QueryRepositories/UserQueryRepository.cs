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
            var query = "exec dbo.UserAccess  @UserId,@AccessName,@ApplicationId";
            var param = new
            {
                @UserId = userId,
                @AccessName = accessName,
                @ApplicationId = applicationId
            };
            try
            {
                var entity = await db.QueryFirstOrDefaultAsync<int>(query, param);
                
                if (entity<1)
                {
                    return false;
                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            

        }

        public async Task<Domain.Entities.UserInfoTbl> UserLoginAsync(long userName, string password, int applicationId)
        {
            var query = "exec dbo.LoginUser @UserName,@Password,@ApplicationId";
            
            var param = new
            {
                @UserName = userName,
                @Password = password,
                @ApplicationId = applicationId
            };

            var entity = await db.QueryFirstAsync<Domain.Entities.UserInfoTbl>(query, param);
            if(entity!=null)
            {
                entity.Password = "";
            }

            return entity;
        }
    }
}
