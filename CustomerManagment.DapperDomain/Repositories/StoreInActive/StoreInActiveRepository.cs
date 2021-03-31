using System.Data;

namespace DataDapper.Repositories.StoreInActive
{
    public class StoreInActiveRepository : Repository<Models.StoreInActiveTbl, int>, IStoreInActiveRepository
    {
        internal StoreInActiveRepository(IDbConnection idbConnection) : base(idbConnection)
        {
        }
    }
}
