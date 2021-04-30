using StoreManagment.Domain.Entities;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Collections.Generic;
using System.Linq;

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
    }

}
