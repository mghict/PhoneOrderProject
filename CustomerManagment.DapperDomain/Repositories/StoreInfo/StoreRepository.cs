using System.Data;

namespace DataDapper.Repositories.StoreInfo
{
    public class StoreRepository : Repository<Models.StoreInfoTbl, double>, IStoreRepository
    {
        internal StoreRepository(IDbConnection idbConnection) : base(idbConnection)
        {
        }
    }
}
