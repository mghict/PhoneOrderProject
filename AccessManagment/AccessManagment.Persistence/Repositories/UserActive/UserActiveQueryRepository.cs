using AccessManagment.Domain.Entities;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace AccessManagment.Persistence.Repositories.UserActive
{
    public class UserActiveQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.UserActiveInfo, long>,
        Domain.IRepositories.IUserActive.IUserActiveQueryRepository
    {
        protected internal UserActiveQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<UserActiveInfo> GetByUserIdCurrentDateAsync(int userId)
        {
            var query = "select * from dbo.[UserActiveInfo] where UserId=@UserId and CreateDate=cast(@CreateDate as date)";

            var param = new
            {
                @UserId= userId,
                @CreateDate=System.DateTime.Now
            };
            try
            {
                var result = await db.QueryFirstAsync<UserActiveInfo>(query, param);
                return result;
            }
            catch
            {
                return new UserActiveInfo();
            }
            
        }

        public async Task<UserModel> GetUserActiveCurrentDateAsync(int appId, float storeId = 0, string SearchKey = "", int PageNumber = 0, int PageSize = 20, int Status = 100)
        {
            var query = "exec dbo.[GetUserActiveCurrentDate] @ApplicationId,@StoreId,@Name,@PageNumber,@PageSize,@Status";

            var param = new
            {
                @ApplicationId = appId,
                @StoreId = storeId,
                @Name = SearchKey,
                @PageNumber = PageNumber,
                @PageSize = PageSize,
                @Status=Status
            };

            var user = new UserModel()
            {
                RowCount = 0,
                Users = new System.Collections.Generic.List<Domain.Entities.UserInfo>()
            };


            using (var lst = await db.QueryMultipleAsync(query, param))
            {
                user.RowCount = lst.ReadFirst<long>();
                user.Users = lst.Read<Domain.Entities.UserInfo>().ToList();
            }

            return user;
        }
    }
}
