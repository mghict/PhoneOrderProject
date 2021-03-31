using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthoManagment.Persistence
{
    public interface IQueryUnitOfWork:BehsamFramework.DapperDomain.Base.IQueryUnitOfWork
    {
        Domain.IRepositories.UserInfo.IUserInfoQueryRepository UserInfoQueryRepository { get; }
    }
}
