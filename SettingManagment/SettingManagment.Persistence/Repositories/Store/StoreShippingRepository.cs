using System;
using System.Data;
using System.Text;

namespace SettingManagment.Persistence.Repositories.Store
{
    public class StoreShippingRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.StoreShippingTbl, int>,
        Domain.IRepositories.Store.IStoreShippingRepository
    {
        protected internal StoreShippingRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
