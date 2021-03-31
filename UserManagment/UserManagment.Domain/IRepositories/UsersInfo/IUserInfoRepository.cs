using System.Threading.Tasks;
using UserManagment.Domain.Entities;

namespace UserManagment.Domain.IRepositories.UserInfo
{
    public interface IUserInfoRepository : BehsamFramework.DapperDomain.Base.IRepository<Entities.UserInfoTbl, int>
    {
        Task<bool> PasswordChange(UserInfoTbl obj);

        Task<UserInfoTbl> GetByUserName(string userName);
    }
}