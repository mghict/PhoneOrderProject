using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BehsamFramework.EFDomain
{
    public class QueryRepository<T>:Base.IQueryRepository<T>
    where T:Entity.IEntity
    {
        internal Microsoft.EntityFrameworkCore.DbContext  DatabaseContext { get; }
        internal Microsoft.EntityFrameworkCore.DbSet<T> DbSet { get; }
        protected QueryRepository(Microsoft.EntityFrameworkCore.DbContext  databaseContext) : base()
        {

            DatabaseContext =
                databaseContext ?? throw new System.ArgumentNullException(paramName: nameof(databaseContext));
            // **************************************************

            DbSet = DatabaseContext.Set<T>();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual async Task<IList<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }
    }

    public class QueryRepository<T,TKeyDataType> : Base.IQueryRepository<T, TKeyDataType>
        where T : Entity.IEntity<TKeyDataType>
        where TKeyDataType:struct
    {
        internal DataBaseContext DatabaseContext { get; }
        internal Microsoft.EntityFrameworkCore.DbSet<T> DbSet { get; }
        internal QueryRepository(DataBaseContext databaseContext) : base()
        {

            DatabaseContext =
                databaseContext ?? throw new System.ArgumentNullException(paramName: nameof(databaseContext));
            // **************************************************

            DbSet = DatabaseContext.Set<T>();
        }

        public virtual async Task<T> GetByIdAsync(TKeyDataType id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual async Task<IList<T>> GetAllAsync()
        {
            return await  DbSet.ToListAsync();
        }
    }
}
