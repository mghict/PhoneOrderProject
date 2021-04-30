using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagement.Persistence
{
    public interface IUnitOfWork:
        BehsamFramework.DapperDomain.Base.IUnitOfWork
    {
        Domain.IRepositories.IOrderRepository OrderRepository { get; }
    }
}
