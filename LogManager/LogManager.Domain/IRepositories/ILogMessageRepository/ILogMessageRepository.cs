using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager.Domain.IRepositories.ILogMessageRepository
{
    public interface ILogMessageRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Entities.LogMessage>
    {
        
    }
}
