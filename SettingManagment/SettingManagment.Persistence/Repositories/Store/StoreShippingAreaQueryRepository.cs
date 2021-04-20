using SettingManagment.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace SettingManagment.Persistence.Repositories.Store
{
    public class StoreShippingAreaQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.StoreShippingAreaTbl, int>,
        Domain.IRepositories.Store.IStoreShippingAreaQueryRepository
    {
        protected internal StoreShippingAreaQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public override async Task<IList<StoreShippingAreaTbl>> GetAllAsync()
        {
            var query = "exec dbo.GetStoreShippingAreaAll";

            var item = await db.QueryAsync<StoreShippingAreaTbl>(query);

            return item.ToList();
        }

        public override async Task<StoreShippingAreaTbl> GetByIdAsync(int id)
        {
            var query = "exec dbo.GetStoreShippingAreaById @id";
            var param = new
            {
                @id = id
            };

            var item = await db.QueryFirstOrDefaultAsync<StoreShippingAreaTbl>(query, param);

            return item;
        }

        public async Task<List<StoreShippingAreaTbl>> GetByStoreId(float storeId)
        {
            var query = "exec dbo.GetStoreShippingAreaByStoreId @storeId";
            var param = new
            {
                @storeId = storeId
            };

            var item = await db.QueryAsync<StoreShippingAreaTbl>(query, param);

            return item.ToList();
        }


    }
}
