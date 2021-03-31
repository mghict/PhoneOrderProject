using BehsamFramework.DapperDomain;
using UserAuthorize.Domain.IRepositories.QueryRepository;

namespace UserAuthorize.Persistence
{
    public class QueryUnitOfWork :
        BehsamFramework.DapperDomain.QueryUnitOfWork,
        IQueryUnitOfWork
    {
        public QueryUnitOfWork(Options options) : base(options)
        {
        }

        private IUserQueryRepository userQueryRepository;
        public IUserQueryRepository UserQueryRepository =>
            userQueryRepository = userQueryRepository ?? new Persistence.QueryRepositories.UserQueryRepository(IDbConnection);
        //-------------------------------------------------
        private IRoleQueryRepository roleQueryRepository;
        public IRoleQueryRepository RoleQueryRepository =>
            roleQueryRepository= roleQueryRepository?? new Persistence.QueryRepositories.RoleQueryRepository(IDbConnection);
        //------------------------------------------------
        private IPageQueryRepository pageQueryRepository;
        public IPageQueryRepository PageQueryRepository =>
            pageQueryRepository = pageQueryRepository ?? new Persistence.QueryRepositories.PageQueryRepository(IDbConnection);
        //------------------------------------------------
        private IApplicationQueryRepository applicationQueryRepository;
        public IApplicationQueryRepository ApplicationQueryRepository =>
            applicationQueryRepository = applicationQueryRepository ?? new Persistence.QueryRepositories.ApplicationQueryRepository(IDbConnection);
        //------------------------------------------------
        private IUserRoleAccessQueryRepository userRoleAccessQueryRepository;
        public IUserRoleAccessQueryRepository UserRoleAccessQueryRepository =>
            userRoleAccessQueryRepository = userRoleAccessQueryRepository ?? new Persistence.QueryRepositories.UserRoleQueryRepository(IDbConnection);
        //------------------------------------------------
        private IRolePageAccessQueryRepository rolePageAccessQueryRepository;
        public IRolePageAccessQueryRepository RolePageAccessQueryRepository =>
            rolePageAccessQueryRepository = rolePageAccessQueryRepository ?? new Persistence.QueryRepositories.RolePageQueryRepository(IDbConnection);
        //------------------------------------------------
    }
}
