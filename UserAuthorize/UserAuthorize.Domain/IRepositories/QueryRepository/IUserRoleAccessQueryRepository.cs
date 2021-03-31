namespace UserAuthorize.Domain.IRepositories.QueryRepository
{
    public interface IUserRoleAccessQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.UserRoleAccessTbl, long>
    {
    }
}
