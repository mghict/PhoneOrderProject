using System.Data;

namespace SettingManagment.Persistence.Repositories.InActive
{
    public class StoreInActiveRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.StoreInActiveTbl, int>,
        Domain.IRepositories.InActive.IStoreInActiveRepository
    {
        protected internal StoreInActiveRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
