using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehsamFramework.DapperDomain.Base;

namespace BehsamFramework.DapperDomain
{
    public abstract class UnitOfWork : QueryUnitOfWork, Base.IUnitOfWork
    {
        public UnitOfWork(Options options) : base(options)
        {
        }
        public async Task SaveAsync()
        {
            return;
        }

    }
}
