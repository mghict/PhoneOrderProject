using System.Data;

namespace StoreManagment.Persistence.QueryRepositories
{
    public class OrderItemsQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.OrderItems, long>,
        Domain.IQueryRepositories.IOrderItemsQueryRepository
    {
        protected internal OrderItemsQueryRepository(IDbConnection _db) : base(_db)
        {
        }
    }

}
