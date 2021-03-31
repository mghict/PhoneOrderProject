using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataDapper.Repositories.UserInfo
{
    public interface IUserRepository:Base.IRepository<Models.UserInfoTbl,int>
    {

        Models.UserInfoTbl GetPass(string userName);
        Task<Models.UserInfoTbl> GetPassAsync(string userName);

        bool UserAccess(int userId, string Permission, string Controller);

        Task<bool> UserAccessAsync(int userId, string Permission, string Controller);
    }
}
