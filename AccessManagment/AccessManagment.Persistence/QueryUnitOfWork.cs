using AccessManagment.Domain.IRepositories.IApplicationInfo;
using AccessManagment.Domain.IRepositories.IPageInfo;
using BehsamFramework.DapperDomain;

namespace AccessManagment.Persistence
{
    public class QueryUnitOfWork : BehsamFramework.DapperDomain.QueryUnitOfWork, IQueryUnitOfWork
    {
        public QueryUnitOfWork(Options options) : base(options)
        {
        }

        private IApplicationInfoQueryRepository _applicationInfoQueryRepository;
        public IApplicationInfoQueryRepository ApplicationInfoQueryRepository =>
            _applicationInfoQueryRepository = _applicationInfoQueryRepository ?? new Repositories.ApplicationInfo.ApplicationInfoQueryRepository(IDbConnection);

        private IPageInfoQueryRepository _pageInfoQueryRepository;
        public IPageInfoQueryRepository PageInfoQueryRepository =>
            _pageInfoQueryRepository = _pageInfoQueryRepository ?? new Repositories.PageInfo.PageInfoQueryRepository(IDbConnection);
    }
}

