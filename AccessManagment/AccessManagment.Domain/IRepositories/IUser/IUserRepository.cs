using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Domain.IRepositories.IUser
{
    public interface IUserRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Entities.UserInfoTbl,int>
    {
        Task ResetUserPassword(int userId,string newPass);
    }
}
