using BehsamFramework.Util;
using SettingManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib;

namespace SettingManagment.Persistence.Repositories.Store
{
    public class StoreQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.Stores, float>,
        Domain.IRepositories.Store.IStoreQueryRepository
    {
        protected internal StoreQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<IList<Stores>> GetStoresAsync(DateTime requestDate, TimeSpan start, TimeSpan end, long customerId)
        {
            var day = requestDate.GetDayOfWeekPersian();
            var query = "exec dbo.GetStores @StartTime,@EndTime,@CustomerId,@RequestDate,@Day ";
            List<Stores> entity = new List<Stores>();
            
            try
            {
                var result =await db.QueryAsync<Stores>(query, new { StartTime= start, EndTime= end, CustomerId= customerId, RequestDate = requestDate, Day = day });
                entity = result.ToList();
            }
            catch (Exception ex)
            {
                entity = new List<Stores>();
            }

            return entity;
        }
    }
}
