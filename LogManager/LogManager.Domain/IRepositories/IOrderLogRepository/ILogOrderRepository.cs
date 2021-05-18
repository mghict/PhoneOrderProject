using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager.Domain.IRepositories.IOrderLogRepository
{
    public interface ILogOrderRepository:
        BehsamFramework.DapperDomain.Base.IRepository<BehsamFramework.Models.OrderLogsModel,long>
    {
    }
}
