using AccessManagment.Domain.IRepositories.IApplicationInfo;
using AccessManagment.Domain.IRepositories.IPageInfo;
using BehsamFramework.DapperDomain;

namespace AccessManagment.Persistence
{
    public class UnitOfWork : BehsamFramework.DapperDomain.UnitOfWork,IUnitOfWork
    {
        public UnitOfWork(Options options) : base(options)
        {
        }

        private IApplicationInfoRepository _applicationInfoRepository;
        public IApplicationInfoRepository ApplicationInfoRepository =>
            _applicationInfoRepository = _applicationInfoRepository ?? new Repositories.ApplicationInfo.ApplicationInfoRepository(IDbConnection);


        private IPageInfoRepository _pageInfoRepository;
        public IPageInfoRepository PageInfoRepository =>
            _pageInfoRepository = _pageInfoRepository ?? new Repositories.PageInfo.PageInfoRepository(IDbConnection);
    }
}

