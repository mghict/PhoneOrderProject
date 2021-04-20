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
using BehsamFramework.Models;
using System.Globalization;

namespace SettingManagment.Persistence.Repositories.Store
{
    public class StoreQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.StoreInfoTbl, float>,
        Domain.IRepositories.Store.IStoreQueryRepository
    {
        protected internal StoreQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<StoreInfoListModel> GetStoreByPaginationAsync(int pageNumber, int pageSize, string search)
        {
            var query = "exec dbo.GetStoreByPagination @Name,@PageNumber,@PageSize";

            
            pageNumber = pageNumber - 1;
            var param = new
            {
                @Name= search,
                @PageNumber = pageNumber <= 0 ? 0 : pageNumber,
                @PageSize = pageSize
            };

            StoreInfoListModel storeList = new StoreInfoListModel();
            storeList.Stores = new List<StoreOrderModel>();

            using (var list = await db.QueryMultipleAsync(query, param))
            {
                storeList.RowCount = list.ReadFirst<long>();
                var temp = list.Read<StoreOrderModel>().ToList();
                storeList.Stores.AddRange(temp);

            }

            return storeList;
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
