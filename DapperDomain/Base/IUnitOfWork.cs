using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Base;

namespace DapperDomain.Base
{
    public interface IUnitOfWork : System.IDisposable
    {
        Repository<T, TKeyDataValue> GetRepository<T, TKeyDataValue>() where T:EntityBase;
    }
}
