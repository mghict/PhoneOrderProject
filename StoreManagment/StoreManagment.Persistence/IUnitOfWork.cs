using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Persistence
{
    public interface IUnitOfWork:
        BehsamFramework.DapperDomain.Base.IUnitOfWork
    {
        Domain.IRepositories.IOrderInfoRepository OrderInfoRepository { get; }
        Domain.IRepositories.IOrderItemsRepository OrderItemsRepository { get; }
        Domain.IRepositories.IOrderDetailRepository OrderDetailRepository { get; }
        Domain.IRepositories.IOrderUserActiveRepository UserActiveRepository { get; }
    }
}
