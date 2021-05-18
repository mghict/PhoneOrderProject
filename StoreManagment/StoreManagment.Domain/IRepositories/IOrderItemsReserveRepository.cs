using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Domain.IRepositories
{
    public interface IOrderItemsReserveRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Domain.Entities.OrderItemsReserve,long>
    {
    }
}
