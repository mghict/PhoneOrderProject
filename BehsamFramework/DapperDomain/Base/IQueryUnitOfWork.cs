using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehsamFramework.DapperDomain.Base
{
    public interface IQueryUnitOfWork : System.IDisposable
    {
        bool IsDisposed { get; }
        Attributes.Authorize.Persistence.UserRepository AuthorizeRepository { get; }
    }

}
