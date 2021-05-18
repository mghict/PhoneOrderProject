using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager.Persistence.Repositories
{
    public class OrderLogRepository :
        BehsamFramework.DapperDomain.Repository<BehsamFramework.Models.OrderLogsModel, long>,
        Domain.IRepositories.IOrderLogRepository.ILogOrderRepository
    {
        protected internal OrderLogRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
