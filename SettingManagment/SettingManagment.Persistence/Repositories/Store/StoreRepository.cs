using System.Data;

namespace SettingManagment.Persistence.Repositories.Store
{
    public class StoreRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.StoreInfoTbl, float>,
        Domain.IRepositories.Store.IStoreRepository
    {
        protected internal StoreRepository(IDbConnection _db) : base(_db)
        {
        }

    }
}
