namespace UserAuthorize.Domain.IRepositories.QueryRepository
{
    public interface IApplicationQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.ApplicationInfoTbl, int>
    {
    }
}
