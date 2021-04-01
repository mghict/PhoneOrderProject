using System.Data;

namespace StoreManagment.Persistence.Repositories
{
    public class OrderItemsRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.OrderItems, long>,
        Domain.IRepositories.IOrderItemsRepository
    {
        protected internal OrderItemsRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
