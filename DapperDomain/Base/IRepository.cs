using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Base;

namespace DapperDomain.Base
{
    public interface IRepository<T, TKeyDataType> where T:EntityBase
    {
        //Get
        T Find(TKeyDataType id);
        Task<T> FindAsync(TKeyDataType id);

        //GetAll
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        //Insert
        dynamic Insert(T obj);
        Task<dynamic> InsertAsync(T obj);
        int Insert(IEnumerable<T> list);
        Task<int> InsertAsync(IEnumerable<T> list);


        //Update
        bool Update(T obj);
        bool Update(IEnumerable<T> list);
        Task<bool> UpdateAsync(T obj);
        Task<bool> UpdateAsync(IEnumerable<T> list);


        //Delete
        bool Delete(T obj);
        bool Delete(TKeyDataType id);
        bool Delete(IEnumerable<T> list);
        bool DeleteAll();

        Task<bool> DeleteAsync(T obj);
        Task<bool> DeleteAsync(TKeyDataType id);
        Task<bool> DeleteAsync(IEnumerable<T> list);
        Task<bool> DeleteAllAsync();
    }
}
