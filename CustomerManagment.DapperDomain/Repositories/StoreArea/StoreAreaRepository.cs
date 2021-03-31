using System.Data;

namespace DataDapper.Repositories.StoreArea
{
    public class StoreAreaRepository : Repository<Models.StoreAreaTbl, int>, IStoreAreaRepository
    {
        internal StoreAreaRepository(IDbConnection idbConnection) : base(idbConnection)
        {
        }
    }
}
