using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthorize.Persistence.QueryRepositories
{
    public class UserQueryRepository : BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.UserInfoTbl, int>,
       Domain.IRepositories.QueryRepository.IUserQueryRepository
    {
        protected internal UserQueryRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
