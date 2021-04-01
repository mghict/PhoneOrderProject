using System.Data;

namespace StoreManagment.Persistence.Repositories
{
    public class OrderDetailRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.OrderInfoDetails, long>,
        Domain.IRepositories.IOrderDetailRepository
    {
        protected internal OrderDetailRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
