using SettingManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace SettingManagment.Persistence.Repositories.InActive
{
    public class StoreInActiveQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.StoreInActiveTbl, int>,
        Domain.IRepositories.InActive.IStoreInActiveQueryRepository
    {
        protected internal StoreInActiveQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<IList<StoreInActiveTbl>> GetByDate(DateTime startDate)
        {
            var query = "select * from StoreInActiveTbl where @Date between FromDate and ToDate";
            var param = new
            {
                @Date = startDate == null ? DateTime.Now : startDate
            };

            var result =await db.QueryAsync<StoreInActiveTbl>(query, param);

            return result.ToList();
        }

        public async Task<IList<StoreInActiveTbl>> GetByStoreAndDate(DateTime startDate,float storeId)
        {
            var query = "select * from StoreInActiveTbl where (@Date between FromDate and ToDate or @Date is null) and ( round(StoreId,3)=round(@StoreId,3) or round(@StoreId)=0 ) ";
            var param = new
            {
                @Date = startDate == null ? DateTime.Now : startDate,
                @StoreId=storeId>0? storeId:0.0f
            };

            var result = await db.QueryAsync<StoreInActiveTbl>(query, param);

            return result.ToList();
        }

        public async Task<IList<StoreInActiveTbl>> GetByStoreId(float storeId)
        {
            var query = "select * from StoreInActiveTbl where round(StoreId,3)=round(@StoreId,3)";
            var param = new
            {
                @StoreId = storeId
            };

            var result = await db.QueryAsync<StoreInActiveTbl>(query, param);

            return result.ToList();
        }
    }
}
