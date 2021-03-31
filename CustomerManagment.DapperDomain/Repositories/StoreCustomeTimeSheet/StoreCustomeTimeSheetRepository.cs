using System.Data;

namespace DataDapper.Repositories.StoreCustomeTimeSheet
{
    public class StoreCustomeTimeSheetRepository : Repository<Models.StoreCustomeTimeSheetTbl, int>, IStoreCustomeTimeSheetRepository
    {
        internal StoreCustomeTimeSheetRepository(IDbConnection idbConnection) : base(idbConnection)
        {
        }
    }
}
