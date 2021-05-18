using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Persistence.Repositories
{
    public class OrderItemsReserveRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.OrderItemsReserve, long>,
        Domain.IRepositories.IOrderItemsReserveRepository
    {
        protected internal OrderItemsReserveRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
