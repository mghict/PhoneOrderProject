using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehsamFramework.DapperDomain.Base
{
    public interface IQueryRepository<T> 
    where T:Entity.IEntity
    {
        //Get By Id
        T GetById(System.Guid id);
        System.Threading.Tasks.Task<T> GetByIdAsync(System.Guid id);


        //Get All
        System.Collections.Generic.IList<T> GetAll();
        System.Threading.Tasks.Task<System.Collections.Generic.IList<T>> GetAllAsync();

        Tuple<IEnumerable<T>, long> GetAll(SerachEntity serachEntity);

        Task<Tuple<IEnumerable<T>, long>> GetAllAsync(SerachEntity serachEntity);

        Tuple<IEnumerable<T>, long> GetAll(int pageNumber, int pageSize);
        Task<Tuple<IEnumerable<T>, long>> GetAllAsync(int pageNumber, int pageSize);

    }
    
    public interface IQueryRepository<T, TKeyDataType> 
        where T : Entity.IEntity<TKeyDataType>
        where TKeyDataType: struct
    {
        //Get By Id
        T GetById(TKeyDataType id);
        System.Threading.Tasks.Task<T> GetByIdAsync(TKeyDataType id);


        //Get All 
        System.Collections.Generic.IList<T> GetAll();
        System.Threading.Tasks.Task<System.Collections.Generic.IList<T>> GetAllAsync();

        Tuple<IEnumerable<T>, long> GetAll(SerachEntity serachEntity);

        Task<Tuple<IEnumerable<T>, long>> GetAllAsync(SerachEntity serachEntity);

        Tuple<IEnumerable<T>, long> GetAll(int pageNumber, int pageSize);
        Task<Tuple<IEnumerable<T>, long>> GetAllAsync(int pageNumber, int pageSize);
    }

}
