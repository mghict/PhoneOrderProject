using System.Data;

namespace StoreManagment.Persistence.QueryRepositories
{
    public class OrderDetailQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.OrderInfoDetails, long>,
        Domain.IQueryRepositories.IOrderDetailQueryRepository
    {
        protected internal OrderDetailQueryRepository(IDbConnection _db) : base(_db)
        {
        }
    }

}
