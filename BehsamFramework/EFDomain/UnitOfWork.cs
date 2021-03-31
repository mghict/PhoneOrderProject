using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehsamFramework.EFDomain
{
    public abstract class UnitOfWork<T> :
        QueryUnitOfWork<T>, Base.IUnitOfWork where T : Microsoft.EntityFrameworkCore.DbContext
    {
        public UnitOfWork(Options options) : base(options: options)
        {
        }

        public async System.Threading.Tasks.Task SaveAsync()
        {
            await DatabaseContext.SaveChangesAsync();
        }
    }
}
