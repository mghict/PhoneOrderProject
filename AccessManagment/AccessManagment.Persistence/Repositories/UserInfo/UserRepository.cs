using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace AccessManagment.Persistence.Repositories.UserInfo
{
    public class UserRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.UserInfoTbl, int>,
        Domain.IRepositories.IUser.IUserRepository
    {
        protected internal UserRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task ResetUserPassword(int userId,  string newPass)
        {
            var query = "update UserInfoTbl set Password=@Pass where Id=@Id";

            var param = new
            {
                @Id = userId,
                @Pass = newPass
            };
                
            var lst =await db.ExecuteAsync(query, param);               

        }

    }
}
