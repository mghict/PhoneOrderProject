using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.Domain.Entities;

namespace UserManagment.Domain.IRepositories.UserInfo
{
    public interface IUserInfoQueryRepository:BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.UserInfoTbl,int>
    {
        Task<UserInfoTbl> GetByUserName(string userName);
    }
}
