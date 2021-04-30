using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagement.Domain.IRepositories
{
    public interface IOrderRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Entities.Order,long>
    {
        Task<bool> UpdateBill(Domain.Entities.OrderRequest order);
    }

    public interface IOrderQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.Order, long>
    {
        Task<Domain.Entities.OrderResponse> GetInfoForBill(long OrderCode);
    }
}
