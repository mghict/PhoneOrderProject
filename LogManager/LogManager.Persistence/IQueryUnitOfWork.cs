using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager.Persistence
{
    public interface IQueryUnitOfWork : BehsamFramework.DapperDomain.Base.IQueryUnitOfWork
    {
        Domain.IRepositories.ILogMessageRepository.ILogMessageQueryRepository LogMessageQueryRepository { get; }
    }
}
