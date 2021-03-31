using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthorize.Domain.IRepositories.Repository
{
    public interface IUserInfoRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Entities.UserInfoTbl,int>
    {
    }
}
