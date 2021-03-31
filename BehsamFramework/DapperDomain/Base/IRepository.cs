using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehsamFramework.DapperDomain.Base
{
    public interface IRepository<T> : IQueryRepository<T> where T : Entity.IEntity
    {

        //Insert
        T Insert(T obj);
        Task<T> InsertAsync(T entity);
        int InsertEnumerable(IEnumerable<T> list);
        Task<int> InsertEnumerableAsync(IEnumerable<T> list);


        //Update
        bool Update(T obj);
        bool UpdateEnumerable(IEnumerable<T> list);
        Task<bool> UpdateAsync(T obj);
        Task<bool> UpdateEnumerableAsync(IEnumerable<T> list);


        //Delete
        bool Delete(T obj);
        Task<bool> DeleteById(System.Guid id);
        bool DeleteEnumerable(IEnumerable<T> list);
        bool DeleteEnumerableId(IEnumerable<System.Guid> list);
        bool DeleteAll();

        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteByIdAsync(System.Guid id);
        Task<bool> DeleteEnumerableAsync(IEnumerable<T> list);
        Task<bool> DeleteEnumerableIdAsync(IEnumerable<System.Guid> list);
        Task<bool> DeleteAllAsync();
    }

    public interface IRepository<T,TKeyDataValue> : IQueryRepository<T,TKeyDataValue> 
        where T : Entity.IEntity<TKeyDataValue>
        where TKeyDataValue:struct
    {

        //Insert
        T Insert(T obj);
        Task<T> InsertAsync(T entity);
        int InsertEnumerable(IEnumerable<T> list);
        Task<int> InsertEnumerableAsync(IEnumerable<T> list);


        //Update
        bool Update(T obj);
        bool UpdateEnumerable(IEnumerable<T> list);
        Task<bool> UpdateAsync(T obj);
        Task<bool> UpdateEnumerableAsync(IEnumerable<T> list);


        //Delete
        bool Delete(T obj);
        Task<bool> DeleteById(TKeyDataValue id);
        bool DeleteEnumerable(IEnumerable<T> list);
        bool DeleteEnumerableId(IEnumerable<TKeyDataValue> list);
        bool DeleteAll();

        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteByIdAsync(TKeyDataValue id);
        Task<bool> DeleteEnumerableAsync(IEnumerable<T> list);
        Task<bool> DeleteEnumerableIdAsync(IEnumerable<TKeyDataValue> list);
        Task<bool> DeleteAllAsync();
    }
}
