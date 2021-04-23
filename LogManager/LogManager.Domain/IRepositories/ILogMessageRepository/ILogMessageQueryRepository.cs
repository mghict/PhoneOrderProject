namespace LogManager.Domain.IRepositories.ILogMessageRepository
{
    public interface ILogMessageQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.LogMessage, long>
    {

    }
}
