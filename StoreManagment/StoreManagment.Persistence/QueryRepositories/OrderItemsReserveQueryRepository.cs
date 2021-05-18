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
    public class OrderItemsReserveQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.OrderItemsReserve, long>,
        Domain.IQueryRepositories.IOrderItemsReserveRepository
    {
        protected internal OrderItemsReserveQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<List<OrderItemsReserve>> GetOrderItemsReserveDetailsAsync(long itemId)
        {
            var query = "exec GetOrderItemsReserveDetails @ItemId";
            var param = new
            {
                @ItemId = itemId
            };

            var result = await db.QueryAsync<OrderItemsReserve>(query, param);

            return result.ToList();
        }
    }
}
