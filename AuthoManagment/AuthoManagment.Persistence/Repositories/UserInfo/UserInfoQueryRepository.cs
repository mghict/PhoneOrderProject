using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthoManagment.Domain.Entities;
using Dapper;

namespace AuthoManagment.Persistence.Repositories.UserInfo
{
    public class UserInfoQueryRepository:
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.UserInfoTbl,int>,
        Domain.IRepositories.UserInfo.IUserInfoQueryRepository
    {
        protected internal UserInfoQueryRepository(IDbConnection db):base(db)
        {
            
        }

        public async Task<UserInfoTbl> Login(string userName, string password, long applicationId)
        {
            string query = "[dbo].[Login]";
            var user=await db.QueryFirstOrDefaultAsync<UserInfoTbl>(sql: query, new { UserName=userName,Password=password, PanelId=applicationId }, commandType: CommandType.StoredProcedure);
            return user;
        }
    }
}
