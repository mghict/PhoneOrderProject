using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BehsamFramework.EFDomain
{
    public class Repository<T> : Base.IRepository<T>
        where T : Entity.IEntity
    {
        internal Microsoft.EntityFrameworkCore.DbContext DatabaseContext { get; }
        internal Microsoft.EntityFrameworkCore.DbSet<T> DbSet { get; }
        protected Repository(Microsoft.EntityFrameworkCore.DbContext databaseContext) 
        {

            DatabaseContext =
                databaseContext ?? throw new System.ArgumentNullException(paramName: nameof(databaseContext));
            // **************************************************

            DbSet = DatabaseContext.Set<T>();
        }

        public async Task<T> InsertAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            return  entity;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
                DbSet.Update(entity);
            });

            return true;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            await Task.Run(() =>
            {
                DbSet.Remove(entity);
            });

            return true;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var entity =await DbSet.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            await Task.Run(() =>
            {
                DbSet.Remove(entity);
            });

            return true;
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
    public class Repository<T,TKeyDataType> :  Base.IRepository<T, TKeyDataType>
        where T : Entity.IEntity<TKeyDataType>
        where TKeyDataType:struct
    {
        internal Microsoft.EntityFrameworkCore.DbContext DatabaseContext { get; }
        internal Microsoft.EntityFrameworkCore.DbSet<T> DbSet { get; }
        protected Repository(Microsoft.EntityFrameworkCore.DbContext databaseContext)
        {

            DatabaseContext =
                databaseContext ?? throw new System.ArgumentNullException(paramName: nameof(databaseContext));
            // **************************************************

            DbSet = DatabaseContext.Set<T>();
        }

        public async Task<T> InsertAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
                DbSet.Update(entity);
            });

            return true;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            await Task.Run(() =>
            {
                DbSet.Remove(entity);
            });

            return true;
        }

        public async Task<bool> DeleteByIdAsync(TKeyDataType id)
        {
            var entity =await DbSet.FindAsync(id);
            if(entity==null)
            {
                return false;
            }

            await Task.Run(() =>
            {
                DbSet.Remove(entity);
            });

            return true;
        }

        public virtual async Task<T> GetByIdAsync(TKeyDataType id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual async Task<IList<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
            
        }
    }
}
