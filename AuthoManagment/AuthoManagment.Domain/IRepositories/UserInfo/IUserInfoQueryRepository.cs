using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthoManagment.Domain.IRepositories.UserInfo
{
    public interface IUserInfoQueryRepository:BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.UserInfoTbl,int>
    {
        Task<Entities.UserInfoTbl> Login(string userName, string password, long applicationId);
    }
}
