using StoreManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace StoreManagment.Persistence.QueryRepositories
{
    public class OrderInfoQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.OrderInfo, long>,
        Domain.IQueryRepositories.IOrderInfoQueryRepository
    {
        protected internal OrderInfoQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<List<GetOrderDetailsByUserId>> getOrderDetailsByUserId(DateTime startDate, DateTime endDate, float storeId = 0.0f, int userId = 0)
        {
            var param = new
            {
                @StartDate = startDate,
                @EndDate = endDate,
                @StoreId=storeId,
                @UserId=userId
            };

            var query = "exec [dbo].[Report_GetOrderDetailsByUserId] @StartDate,@EndDate,@UserId,@StoreId";

            var lst = (await db.QueryAsync<GetOrderDetailsByUserId>(query, param)).ToList();

            return lst;
        }

        public async Task<GetOrderInfoWithItems> getOrderInfoWithItems(long OrderCode)
        {
            var getOrderInfoWithItems = new GetOrderInfoWithItems();

            var param = new
            {
                @OrderCode = OrderCode
            };

            var query = "exec [dbo].[Report_GetOrderInfoWithItems] @OrderCode";

            using (var list = await db.QueryMultipleAsync(query, param))
            {
                var getOrderInfo = list.ReadFirst<GetOrderInfo>();
                var orderItems = list.Read<GetOrderItems>().ToList();

                getOrderInfoWithItems.OrderInfo = getOrderInfo;
                getOrderInfoWithItems.OrderItems = orderItems;
            }

            return getOrderInfoWithItems;
        }

        public async Task<List<GetSummeryOrderByDate>> getSummeryOrderByDates(DateTime startDate, DateTime endDate)
        {
            var param = new
            {
                @StartDate = startDate,
                @EndDate = endDate
            };

            var query = "exec [dbo].[Report_GetSummeryOrderByDate] @StartDate,@EndDate";

            var lst =(await db.QueryAsync<GetSummeryOrderByDate>(query, param)).ToList();

            return lst;
        }

        public async Task<List<GetSummeryOrderStatusByDate>> getSummeryOrderStatusByDate(float storeId, DateTime startDate, DateTime endDate)
        {
            var param = new
            {
                @StartDate = startDate,
                @EndDate = endDate,
                @StoreId=storeId
            };

            var query = "exec [dbo].[Report_GetSummeryOrderStatusByDate] @StartDate,@EndDate,@StoreId";

            var lst = (await db.QueryAsync<GetSummeryOrderStatusByDate>(query, param)).ToList();

            return lst;
        }

        public async Task<List<GetSummeryOrderStatusDetailsByDate>> getSummeryOrderStatusDetailsByDate(float storeId, DateTime startDate, DateTime endDate, int status)
        {
            var param = new
            {
                @StartDate = startDate,
                @EndDate = endDate,
                @StoreId = storeId,
                @Status=status
            };

            var query = "exec [dbo].[Report_GetSummeryOrderStatusDetailsByDate] @StartDate,@EndDate,@StoreId,@Status";

            var lst = (await db.QueryAsync<GetSummeryOrderStatusDetailsByDate>(query, param)).ToList();

            return lst;
        }
    }

}
