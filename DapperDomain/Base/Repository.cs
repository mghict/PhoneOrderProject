using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Dapper.Mapper;
using System.Data;
using DTOs.Base;

namespace DapperDomain.Base
{
    public class Repository<T, TKeyDataType> : IRepository<T, TKeyDataType> where T :DTOs.Base.EntityBase
    {
        protected IDbConnection db { get; }
        protected Repository(IDbConnection _db)
        {
            db = _db;
        }

        public T Find(TKeyDataType id)
        {
            return db.Get<T>(id);
        }
        public async Task<T> FindAsync(TKeyDataType id)
        {
            return await db.GetAsync<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return db.GetAll<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await db.GetAllAsync<T>();
        }

        public dynamic Insert(T obj)
        {
            dynamic id = db.Insert<T>(obj);

            return id;
        }

        public async Task<dynamic> InsertAsync(T obj)
        {
            dynamic id =await db.InsertAsync<T>(obj);
            return id;
        }

        public int Insert(IEnumerable<T> list)
        {
            var count = db.Insert< IEnumerable<T>>(list);
            return (int)count;
        }

        public async Task<int> InsertAsync(IEnumerable<T> list)
        {
            var count =await db.InsertAsync< IEnumerable<T>>(list);
            return (int)count;
        }

        public bool Update(T obj)
        {
            return db.Update<T>(obj);
        }

        public bool Update(IEnumerable<T> list)
        {
            return db.Update<IEnumerable<T>>(list);
        }

        public async Task<bool> UpdateAsync(T obj)
        {
            return await db.UpdateAsync<T>(obj);
        }

        public async Task<bool> UpdateAsync(IEnumerable<T> list)
        {
            return await db.UpdateAsync<IEnumerable<T>>(list);
        }

        public bool Delete(T obj)
        {
            return db.Delete<T>(obj);
        }

        public bool Delete(IEnumerable<T> list)
        {
            return db.Delete<IEnumerable<T>>(list);
        }

        public bool DeleteAll()
        {
            return db.DeleteAll<T>();
        }

        public async Task<bool> DeleteAsync(T obj)
        {
            return await db.DeleteAsync<T>(obj);
        }

        public async Task<bool> DeleteAsync(IEnumerable<T> list)
        {
            return await db.DeleteAsync<IEnumerable<T>>(list); 
        }

        public async Task<bool> DeleteAllAsync()
        {
            return await db.DeleteAllAsync<T>();
        }

        public bool Delete(TKeyDataType id)
        {
            T obj= db.Get<T>(id);
            return db.Delete<T>(obj);
        }

        public async Task<bool> DeleteAsync(TKeyDataType id)
        {
            T obj =await db.GetAsync<T>(id);
            return await db.DeleteAsync<T>(obj);
        }
    }
}
