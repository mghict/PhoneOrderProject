using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using UserManagment.Domain.Entities;

namespace UserManagment.Persistence.Repositories.UsersInfo
{
    public class UsersInfoQueryRepository:
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.UserInfoTbl,int>,
        Domain.IRepositories.UserInfo.IUserInfoQueryRepository
    {
        protected internal UsersInfoQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<UserInfoTbl> GetByUserName(string userName)
        {
            return await Task.Run(() =>
            {
                string query = "select * from UserInfoTbl where UserName=@UserName";
                var entity = db.QueryFirstOrDefaultAsync<UserInfoTbl>(query, new { @UserName = userName });
                if (entity.Result == null)
                {
                    throw new Exception("UserName Not Found");
                }

                return entity;
            });
        }
    }
}
