using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager.Persistence.Repositories
{
    public class LogMessageRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.LogMessage, long>,
        Domain.IRepositories.ILogMessageRepository.ILogMessageRepository
    {
        protected internal LogMessageRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
