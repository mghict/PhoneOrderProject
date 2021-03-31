using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IUserInfoRepository : Base.IRepository<Models.UserInfoTbl>
    {
        Models.UserInfoTbl GetByUsername(string username);

        System.Threading.Tasks.Task<Models.UserInfoTbl> GetByUsernameAsync(string username);

        System.Collections.Generic.List<Models.UserInfoTbl> GetActive();

        Task<List<Models.UserInfoTbl>> GetActiveAsync();
    }
}
