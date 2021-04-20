using System.Data;

namespace SettingManagment.Persistence.Repositories.Store
{
    public class StoreShippingAreaRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.StoreShippingAreaTbl, int>,
        Domain.IRepositories.Store.IStoreShippingAreaRepository
    {
        protected internal StoreShippingAreaRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
