using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthorize.Persistence.Repositories
{
    public class UserRepository : BehsamFramework.DapperDomain.Repository<Domain.Entities.UserInfoTbl, int>,
        Domain.IRepositories.Repository.IUserInfoRepository
    {
        protected internal UserRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
