using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Domain.IQueryRepositories
{
    public interface IOrderItemsReserveRepository:
        BehsamFramework.DapperDomain.Base.IQueryRepository<Domain.Entities.OrderItemsReserve,long>
    {
        Task<List<Domain.Entities.OrderItemsReserve>> GetOrderItemsReserveDetailsAsync(long itemId); 
    }
}
