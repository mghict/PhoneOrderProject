using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Persistence.QueryRepositories
{
    public class OrderInfoQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.OrderInfo, long>,
        Domain.IQueryRepositories.IOrderInfoQueryRepository
    {
        protected internal OrderInfoQueryRepository(IDbConnection _db) : base(_db)
        {
        }
    }

}
