using System.Data;

namespace SettingManagment.Persistence.Repositories.Store
{
    public class ShippingGlobalQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.StoreGeneralShippingTbl, byte>,
        Domain.IRepositories.Store.IShippingGlobalQueryRepository
    {
        protected internal ShippingGlobalQueryRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
