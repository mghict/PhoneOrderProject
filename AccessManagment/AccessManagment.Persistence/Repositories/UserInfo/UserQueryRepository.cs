using AccessManagment.Domain.Entities;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace AccessManagment.Persistence.Repositories.UserInfo
{
    public class UserQueryRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.UserInfoTbl, int>,
        Domain.IRepositories.IUser.IUserQueryRepository
    {
        protected internal UserQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<UserModel> GetAllBySearchAsync(string SearchKey = "", int PageNumber = 0, int PageSize = 20)
        {
            var query = "exec dbo.[GetUsers] @Name,@PageNumber,@PageSize";
            
            var param = new
            {
                @Name = SearchKey,
                @PageNumber = PageNumber,
                @PageSize = PageSize
            };

            var user = new UserModel()
            {
                RowCount = 0,
                Users = new System.Collections.Generic.List<Domain.Entities.UserInfo>()
            };


            using (var lst=await db.QueryMultipleAsync(query,param))
            {
                user.RowCount = lst.ReadFirst<long>();
                user.Users =  lst.Read<Domain.Entities.UserInfo>().ToList();
            }

            return user;
        }
    }
}
