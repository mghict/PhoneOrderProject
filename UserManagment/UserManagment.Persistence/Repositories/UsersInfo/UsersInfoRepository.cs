using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using UserManagment.Domain.Entities;

namespace UserManagment.Persistence.Repositories.UsersInfo
{
    public class UsersInfoRepository:
        BehsamFramework.DapperDomain.Repository<Domain.Entities.UserInfoTbl,int>,
        Domain.IRepositories.UserInfo.IUserInfoRepository
    {
        protected internal UsersInfoRepository(IDbConnection _db) : base(_db)
        {
        }

        public override async Task<bool> UpdateAsync(UserInfoTbl obj)
        {
            return await Task.Run(() =>
            {
                string query = "update UserInfoTbl set" +
                               "UserName=@UserName ," +
                               "Status=@Status ," +
                               "PhoneNumber=@PhoneNumber ," +
                               "LastName=@LastName ," +
                               "FirstName=@FirstName " +
                               "where Id=@Id";
                var result = db.ExecuteAsync(query, new
                {
                    @UserName = obj.UserName,
                    @Status = obj.Status,
                    @PhoneNumber = obj.PhoneNumber,
                    @LastName = obj.LastName,
                    @FirstName = obj.FirstName,
                    @Id = obj.Id
                });

                if (result.Result < 0)
                    return false;

                return true;
            });
        }

        public virtual async Task<bool> PasswordChange(UserInfoTbl obj)
        {
            return await Task.Run(() =>
            {
                /*var entity = GetByUserName(obj.UserName);

                if (entity.Result == null)
                {
                    throw new Exception("UserName Not Found");
                }*/

                string query = "update UserInfoTbl set" +
                               "password=@password ," +
                               "where Id=@Id";

                var result = db.ExecuteAsync(query, new
                {
                    @password = obj.Password,
                    @Id = obj.Id
                });

                if (result.Result < 0)
                    return false;

                return true;

            });
        }

        public async Task<UserInfoTbl> GetByUserName(string userName)
        {
            return await Task.Run( () =>
            {
                string query = "select * from UserInfoTbl where UserName=@UserName";
                var entity = db.QueryFirstOrDefaultAsync<UserInfoTbl>(query, new {@UserName = userName});
                if (entity.Result == null)
                {
                    throw new Exception("UserName Not Found");
                }

                return entity;
            });
        }
        
    }
}
