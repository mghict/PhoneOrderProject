using System.Data;

namespace DataDapper.Repositories.StoreProduct
{
    public class StoreProductRepository : Repository<Models.StoreProductTbl, long>, IStoreProductRepository
    {
        internal StoreProductRepository(IDbConnection idbConnection) : base(idbConnection)
        {
        }
    }
}
