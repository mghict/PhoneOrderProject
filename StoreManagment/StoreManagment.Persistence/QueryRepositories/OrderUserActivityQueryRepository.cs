using StoreManagment.Domain.Entities;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System;

namespace StoreManagment.Persistence.QueryRepositories
{
    public class OrderUserActivityQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.CustomerPreOrderUserActive, long>,
        Domain.IQueryRepositories.IOrderUserActiveQueryRepository
    {
        protected internal OrderUserActivityQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<List<CustomerPreOrderUserActive>> GetOrderUserActivityDetailsinCurrentDate(int userId)
        {
            var query = " exec dbo.OrderUserActivityDetailsinCurrentDate @UserId";

            var param = new
            {
                @UserId=userId
            };

            var result = await db.QueryAsync<CustomerPreOrderUserActive>(query, param);

            return result.ToList();
        }

        public async Task<List<CustomerPreOrderUserActiveSummery>> GetOrderUserActivitySummeryinCurrentDate(int userId)
        {
            var query = " exec dbo.OrderUserActivitySummeryinCurrentDate @UserId";

            var param = new
            {
                @UserId = userId
            };

            var result = await db.QueryAsync<CustomerPreOrderUserActiveSummery>(query, param);

            return result.ToList();
        }


        //-------------------------------------------
        //-------------------------------------------
        public async Task<List<CustomerPreOrderUserActive>> GetOrderUserActivityDetailsInDate(DateTime orderDate, float storeId = 0, int userId = 0)
        {
            var query = " exec dbo.[Report_GetUserActivityDetailsInDate] @UserId,@OrderDate,@StoreId";

            var param = new
            {
                @UserId = userId,
                @StoreId = storeId,
                @OrderDate = orderDate
            };

            var result = await db.QueryAsync<CustomerPreOrderUserActive>(query, param);

            return result.ToList();
        }

        public async Task<List<CustomerPreOrderUserActiveSummery>> GetOrderUserActivitySummeryInDate(DateTime orderDate, float storeId = 0, int userId = 0, int roleId = 0)
        {
            var query = " exec dbo.[Report_GetUserActivitySummeryInDate] @StoreId,@OrderDate,@UserId,@RoleId";

            var param = new
            {
                @UserId = userId,
                @StoreId = storeId,
                @OrderDate = orderDate,
                @RoleId=roleId
            };

            var result = await db.QueryAsync<CustomerPreOrderUserActiveSummery>(query, param);

            return result.ToList();
        }

        public async Task<List<UserActivityLogs>> GetOrderUserActivityLogs(DateTime fromDate, DateTime toDate, int userId = 0)
        {
            var query = " exec dbo.[OrderUserActivityLog] @UserId,@FromDate,@ToDate";

            var param = new
            {
                @UserId = userId,
                @FromDate=fromDate,
                @ToDate = toDate
            };

            var result = await db.QueryAsync<UserActivityLogs>(query, param);

            return result.ToList();
        }

        public async Task<List<OrderUserActivityByStatus>> GetOrderUserActivityByStatus(int userId, int status)
        {
            var query = " exec dbo.[OrderUserActivityByStatus] @UserId,@Status";

            var param = new
            {
                @UserId = userId,
                @Status = status
            };

            var result = await db.QueryAsync<OrderUserActivityByStatus>(query, param);

            return result.ToList();
        }
    }

}
