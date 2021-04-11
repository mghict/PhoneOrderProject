using BehsamFramework.DapperDomain;
using UserManagment.Domain.IRepositories.ApplicationInfo;

namespace UserManagment.Persistence
{
    public class UnitOfWork :
        BehsamFramework.DapperDomain.UnitOfWork,
        IUnitOfWork
    {
        public UnitOfWork(Options options) : base(options)
        {
        }

        private IApplicationInfoRepository _applicationInfoRepository;
        public IApplicationInfoRepository ApplicationInfoRepository =>
            _applicationInfoRepository = _applicationInfoRepository ?? new Repositories.ApplicationInfo.ApplicationInfoRepository(IDbConnection);
    }
}
