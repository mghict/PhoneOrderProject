using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthorize.Domain.IRepositories.QueryRepository
{
    public interface IUserQueryRepository:
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.UserInfoTbl,int>
    {
        Task<Domain.Entities.UserInfoTbl> UserLoginAsync(long userName, string password, int applicationId);

        Task<bool> UserAccessAsync(int userId, string accessName, int applicationId);
    }
}
