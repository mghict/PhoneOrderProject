using System.Data;

namespace DataDapper.Repositories.StoreTimeSheet
{
    public class StoreTimeSheetRepository : Repository<Models.StoreTimeSheetTbl, int>, IStoreTimeSheetRepository
    {
        internal StoreTimeSheetRepository(IDbConnection idbConnection) : base(idbConnection)
        {
        }
    }
}
