using SettingManagment.Domain.Entities;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace SettingManagment.Persistence.Repositories.Store
{
    public class StoreShippingQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.StoreShippingTbl, int>,
        Domain.IRepositories.Store.IStoreShippingQueryRepository
    {
        protected internal StoreShippingQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<StoreShippingTbl> GetByStoreId(float storeId)
        {
            var query = "Select * from StoreShippingTbl where Round(StoreID,3)=Round(@StoreID,3)";
            var param = new
            {
                @StoreID = storeId
            };

            var item = await db.QueryFirstAsync<StoreShippingTbl>(query, param);

            return item;
        }
    }
}
