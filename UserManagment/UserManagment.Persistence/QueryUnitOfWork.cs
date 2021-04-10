using BehsamFramework.DapperDomain;
using UserManagment.Domain.IRepositories.ApplicationInfo;


namespace UserManagment.Persistence
{
    public class QueryUnitOfWork :
        BehsamFramework.DapperDomain.QueryUnitOfWork,
        IQueryUnitOfWork
    {
        
        private IApplicationInfoQueryRepository _applicationInfoQueryRepository;
        public QueryUnitOfWork(Options options) : base(options)
        {
        }


        public IApplicationInfoQueryRepository ApplicationInfoQueryRepository =>
            _applicationInfoQueryRepository = _applicationInfoQueryRepository ?? new Repositories.ApplicationInfo.ApplicationInfoQueryRepository(IDbConnection);
    }
}