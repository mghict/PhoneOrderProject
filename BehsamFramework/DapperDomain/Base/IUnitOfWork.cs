using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehsamFramework.DapperDomain.Base
{
    public interface IUnitOfWork : IQueryUnitOfWork
    {
        System.Threading.Tasks.Task SaveAsync();
    }
}
