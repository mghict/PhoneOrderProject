using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Base
{
    public class Repository<T> : object, IRepository<T> where T : Models.Base.Entity
        //public abstract class Repository<T> : object, IRepository<T> where T : Models.Base.Entity
    {
        internal Repository(DatabaseContext databaseContext) : base()
        {

            DatabaseContext =
                databaseContext ?? throw new System.ArgumentNullException(paramName: nameof(databaseContext));
            // **************************************************

            DbSet = DatabaseContext.Set<T>();
        }

        // **********
        internal DatabaseContext DatabaseContext { get; }
        //internal DatabaseContext DatabaseContext { get; set; }
        // **********

        // **********
        internal Microsoft.EntityFrameworkCore.DbSet<T> DbSet { get; }
        //internal Microsoft.EntityFrameworkCore.DbSet<T> DbSet { get; set; }
        // **********

        public virtual T Insert(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            DbSet.Add(entity);
            return entity;
        }

        public virtual async System.Threading.Tasks.Task<T> InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            await DbSet.AddAsync(entity);

            return entity;
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            DbSet.Update(entity);

            //Microsoft.EntityFrameworkCore.EntityState
            //	entityState = DatabaseContext.Entry(entity).State;

            //if (entityState == Microsoft.EntityFrameworkCore.EntityState.Detached)
            //{
            //	DbSet.Attach(entity);
            //}

            ////entityState =
            ////	DatabaseContext.Entry(entity).State;

            ////DatabaseContext.Entry(entity).State =
            ////	Microsoft.EntityFrameworkCore.EntityState.Modified;

            ////entityState =
            ////	DatabaseContext.Entry(entity).State;

            //_ =
            //	DatabaseContext.Entry(entity).State;

            //DatabaseContext.Entry(entity).State =
            //	Microsoft.EntityFrameworkCore.EntityState.Modified;

            //_ =
            //	DatabaseContext.Entry(entity).State;
        }

        public virtual async System.Threading.Tasks.Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            //DbSet.Update(entity);

            await System.Threading.Tasks.Task.Run(() =>
            {
                DbSet.Update(entity);
            });
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            DbSet.Remove(entity);

            //Microsoft.EntityFrameworkCore.EntityState
            //	entityState = DatabaseContext.Entry(entity).State;

            //if (entityState == Microsoft.EntityFrameworkCore.EntityState.Detached)
            //{
            //	DbSet.Attach(entity);
            //}

            //entityState =
            //	DatabaseContext.Entry(entity).State;

            //DbSet.Remove(entity);

            //entityState =
            //	DatabaseContext.Entry(entity).State;
        }

        public virtual async System.Threading.Tasks.Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            await System.Threading.Tasks.Task.Run(() =>
            {
                DbSet.Remove(entity);
            });
        }

        public virtual System.Collections.Generic.IList<T> GetAll()
        {

            var result =
                DbSet.ToList()
                ;

            return result;
        }

        public virtual async System.Threading.Tasks.Task<System.Collections.Generic.IList<T>> GetAllAsync()
        {


            var result =
                await
                DbSet.ToListAsync()
                ;

            return result;

        }

        /*public virtual T GetById(System.Guid id)
		{
			return DbSet.Find(keyValues: id);
		}

		public virtual async System.Threading.Tasks.Task<T> GetByIdAsync(System.Guid id)
		{
			return await DbSet.FindAsync(keyValues: id);
		}

		public virtual bool DeleteById(System.Guid id)
		{
			T entity = GetById(id);

			if (entity == null)
			{
				return false;
			}

			Delete(entity);

			return true;
		}

		public virtual async System.Threading.Tasks.Task<bool> DeleteByIdAsync(System.Guid id)
		{
			T entity =
				await GetByIdAsync(id);

			if (entity == null)
			{
				return false;
			}

			await DeleteAsync(entity);

			return true;
		}
*/
    }
}
