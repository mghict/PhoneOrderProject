using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthoManagment.Domain.IRepositories.UserInfo;
using AuthoManagment.Persistence.Repositories.UserInfo;
using BehsamFramework.DapperDomain;

namespace AuthoManagment.Persistence
{
    public class QueryUnitOfWork:
        BehsamFramework.DapperDomain.QueryUnitOfWork,
        Persistence.IQueryUnitOfWork
    {
        public QueryUnitOfWork(Options options) : base(options)
        {
        }

        private IUserInfoQueryRepository _userInfoQueryRepository;

        public IUserInfoQueryRepository UserInfoQueryRepository =>
            _userInfoQueryRepository = _userInfoQueryRepository ?? new UserInfoQueryRepository(IDbConnection);
    }
}
