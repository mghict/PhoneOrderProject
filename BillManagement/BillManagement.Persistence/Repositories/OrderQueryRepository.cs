using BillManagement.Domain.Entities;
using System;
using System.Data;
using System.Threading.Tasks;
using BehsamFramework.Util;
using BehsamFramework.Utility;
using Dapper;
using System.Linq;

namespace BillManagement.Persistence.Repositories
{
    public class OrderQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.Order, long>,
        Domain.IRepositories.IOrderQueryRepository
    {
        protected internal OrderQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<OrderResponse> GetInfoForBill(long OrderCode)
        {
            var query = " exec ServiceBill_GetOrderDetails @OrderCode";
            var param = new
            {
                @OrderCode = OrderCode
            };

            OrderResponse resp = new OrderResponse()
            {
                CustomerName = "",
                OrderCode = OrderCode,
                OrderDate = DateTime.Now.ToPersianDate(),
                StoreId = 0,
                OrderItems = new System.Collections.Generic.List<OrderItems>()
            };


            using (var lst = await db.QueryMultipleAsync(query, param))
            {
                resp = await lst.ReadFirstOrDefaultAsync<OrderResponse>();
                resp.OrderItems = (await lst.ReadAsync<OrderItems>())?.ToList();
            }

            return resp;

        }
    }
}
