using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehsamFramework.DapperDomain.Base;
using BehsamFramework.Util;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using FluentResults;

namespace BehsamFramework.DapperDomain
{
    public class Repository<T> : Base.IRepository<T>
    where T : Entity.IEntity
    {
        protected IDbConnection db { get; }

        protected Repository(IDbConnection _db)
        {
            db = _db;
        }

        #region Insert
        public virtual T Insert(T obj)
        {
            db.Insert(obj);
            return obj;
        }
        public virtual async Task<T> InsertAsync(T entity)
        {
            await db.InsertAsync(entity);
            return entity;
        }
        public virtual int InsertEnumerable(IEnumerable<T> list)
        {
            long count = db.Insert(list);
            return count.ToInt();
        }
        public virtual async Task<int> InsertEnumerableAsync(IEnumerable<T> list)
        {
            long count = await db.InsertAsync(list);
            return count.ToInt();
        }


        #endregion

        #region Update

        public virtual bool Update(T obj)
        {
            return db.Update(obj);
        }
        public virtual bool UpdateEnumerable(IEnumerable<T> list)
        {
            return db.Update(list);
        }
        public virtual async Task<bool> UpdateAsync(T obj)
        {
            return await db.UpdateAsync(obj);
        }
        public virtual async Task<bool> UpdateEnumerableAsync(IEnumerable<T> list)
        {
            return await db.UpdateAsync(list);
        }

        #endregion

        #region Delete
        public virtual bool Delete(T obj)
        {
            return db.Delete(obj);
        }
        public virtual async Task<bool> DeleteById(Guid id)
        {
            return await db.DeleteAsync(db.GetAsync<T>(id));
        }
        public virtual bool DeleteEnumerable(IEnumerable<T> list)
        {
            return db.Delete(list);
        }
        public virtual bool DeleteEnumerableId(IEnumerable<Guid> list)
        {

            List<T> entityLst = new List<T>();

            Task.Run(() =>
            {

                foreach (var id in list)
                {
                    T entity = db.Get<T>(id);
                    if (entity != null)
                    {
                        entityLst.Add(entity);
                    }
                }
            });

            return db.Delete(entityLst);
        }
        public virtual bool DeleteAll()
        {
            return db.DeleteAll<T>();
        }
        public virtual async Task<bool> DeleteAsync(T entity)
        {
            return await db.DeleteAsync(entity);
        }
        public virtual async Task<bool> DeleteByIdAsync(Guid id)
        {
            var entity = db.GetAsync<T>(id);
            return await db.DeleteAsync(entity.Result);
        }
        public virtual async Task<bool> DeleteEnumerableAsync(IEnumerable<T> list)
        {
            return await db.DeleteAsync(list);
        }
        public virtual async Task<bool> DeleteEnumerableIdAsync(IEnumerable<Guid> list)
        {
            var entityLst = await Task.Run(() =>
             {
                 List<T> entityList = new List<T>();

                 foreach (var id in list)
                 {
                     var entity = db.GetAsync<T>(id);
                     if (entity.Result != null)
                     {
                         entityList.Add(entity.Result);
                     }
                 }

                 return entityList;
             });

            return await db.DeleteAsync(entityLst);

        }
        public virtual async Task<bool> DeleteAllAsync()
        {
            return await db.DeleteAllAsync<T>();
        }

        #endregion

        #region GetAll
        public virtual IList<T> GetAll()
        {
            return db.GetAll<T>().ToList();
        }

        public virtual async Task<IList<T>> GetAllAsync()
        {
            var data = await db.GetAllAsync<T>();
            return data.ToList();
        }

        public Tuple<IEnumerable<T>, long> GetAll(SerachEntity searchEntity)
        {
            string tableName = typeof(T).Name;

            string query = CreateFindQuery(searchEntity);
            string countQuery = $"select APPROX_COUNT_DISTINCT(*) count from {tableName}";

            IEnumerable<T> resul= db.Query<T>(query);
            long count = db.QueryFirstOrDefault<long>(countQuery);

            return new Tuple<IEnumerable<T>, long>(resul, count);

        }

        public async Task<Tuple<IEnumerable<T>, long>> GetAllAsync(SerachEntity searchEntity)
        {
            string tableName = "", query = "", countQuery = "";

            await Task.Run(() =>
            {
                tableName = typeof(T).Name;

                query = CreateFindQuery(searchEntity);
                countQuery = $"select APPROX_COUNT_DISTINCT(*) count from {tableName}";
            });


            var resul =  db.QueryAsync<T>(query);
            var count =  db.QueryFirstOrDefaultAsync<long>(countQuery);

            return new Tuple<IEnumerable<T>, long>(resul.Result, count.Result);
        }

        public Tuple<IEnumerable<T>, long> GetAll(int pageNumber, int pageSize)
        {
            string tableName = "", query = "", countQuery = "";
            tableName = typeof(T).Name;

            query = CreateFindQuery(pageNumber, pageSize);
            countQuery = $"select APPROX_COUNT_DISTINCT(*) count from {tableName}";

            var resul = db.Query<T>(query);
            var count = db.QueryFirstOrDefault<long>(countQuery);

            return new Tuple<IEnumerable<T>, long>(resul, count);
        }

        public async Task<Tuple<IEnumerable<T>, long>> GetAllAsync(int pageNumber, int pageSize)
        {
            string tableName = "", query = "", countQuery = "";
            await Task.Run(() =>
            {
                tableName = typeof(T).Name;

                query = CreateFindQuery(pageNumber, pageSize);
                countQuery = $"select APPROX_COUNT_DISTINCT(*) count from {tableName}";
            });


            var resul = db.QueryAsync<T>(query);
            var count = db.QueryFirstOrDefaultAsync<long>(countQuery);

            return new Tuple<IEnumerable<T>, long>(resul.Result, count.Result);
        }

        protected virtual string CreateFindQuery(int pageNumber, int pageSize)
        {
            string tableName = typeof(T).Name;
            string query = $"select * from {tableName} order by Id";


            int next = pageSize;
            int Offset = (pageNumber < 1 ? 0 : pageNumber - 1) * next;
            query += $" offset {Offset} ROWS FETCH NEXT {next} ROWS ONLY ";

            return query;
        }

        private string CreateFindQuery(SerachEntity serachEntity)
        {
            string tableName = typeof(T).Name;
            string query = $"select * from {tableName}";
            

            if (serachEntity != null)
            {
                string conditions = "";

                if (serachEntity.Conditions != null && serachEntity.Conditions.Count > 0)
                {


                    foreach (var condition in serachEntity.Conditions)
                    {
                        if (!string.IsNullOrWhiteSpace(conditions.Trim()))
                        {
                            conditions += " and ";
                        }

                        string operation = "";
                        string value = $"{condition.FiledValue}";

                        switch (condition.ConditionType)
                        {
                            case ConditionType.Equal:
                                if (condition.FiledValue is string || condition.FiledValue is DateTime)
                                {
                                    operation = $"=''{value}''";
                                }
                                else
                                {
                                    operation = $"={value}";
                                }

                                break;
                            case ConditionType.Great:
                                operation = $">{value}";
                                break;
                            case ConditionType.GreatThan:
                                operation = $">={value}";
                                break;
                            case ConditionType.Less:
                                operation = $"<{value}";
                                break;
                            case ConditionType.LessThan:
                                operation = $"<={value}";
                                break;
                            case ConditionType.Contains:
                                operation = $"like '%{value}%'";
                                break;

                        }

                        conditions += $"{condition.FieldName} {operation} ";
                    }

                    if (!string.IsNullOrWhiteSpace(conditions.Trim()))
                    {
                        query += $" where {conditions}";
                    }

                }


                string asc = "";

                foreach (var ascValue in serachEntity.Asc)
                {

                    if (!string.IsNullOrWhiteSpace(ascValue.Trim()))
                    {
                        if (!string.IsNullOrWhiteSpace(asc.Trim()))
                        {
                            asc += ",";
                        }
                        asc += ascValue + " asc";
                    }
                }

                foreach (var descValue in serachEntity.Desc)
                {

                    if (!string.IsNullOrWhiteSpace(descValue.Trim()))
                    {
                        if (!string.IsNullOrWhiteSpace(asc.Trim()))
                        {
                            asc += ",";
                        }
                        asc += descValue + " desc";
                    }
                }

                if (!string.IsNullOrWhiteSpace(asc.Trim()))
                {
                    query += $" order by {asc}";
                }
                int next = serachEntity.PageSize;
                int Offset = (serachEntity.PageNo < 1 ? 0 : serachEntity.PageNo - 1) * next;
                query += $" offset {Offset} ROWS FETCH NEXT {next} ROWS ONLY ";
            }

            return query;
        }

        #endregion

        #region GetByID
        public virtual T GetById(Guid id)
        {
            return db.Get<T>(id);
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            var data = await db.GetAsync<T>(id);
            return data;
        }

        #endregion
    }

    public class Repository<T, TKeyDataType> : Base.IRepository<T, TKeyDataType>
        where T : Entity.IEntity<TKeyDataType>
        where TKeyDataType : struct
    {
        protected IDbConnection db { get; }
        protected Repository(IDbConnection _db)
        {
            db = _db;
        }

        //Insert
        public virtual T Insert(T obj)
        {
            db.Insert(obj);
            return obj;
        }
        public virtual async Task<T> InsertAsync(T entity)
        {
            await db.InsertAsync(entity);
            return entity;
        }
        public virtual int InsertEnumerable(IEnumerable<T> list)
        {
            long count = db.Insert(list);
            return count.ToInt();
        }
        public virtual async Task<int> InsertEnumerableAsync(IEnumerable<T> list)
        {
            long count = await db.InsertAsync(list);
            return count.ToInt();
        }

        //Update
        public virtual bool Update(T obj)
        {
            return db.Update(obj);
        }
        public virtual bool UpdateEnumerable(IEnumerable<T> list)
        {
            return db.Update(list);
        }
        public virtual async Task<bool> UpdateAsync(T obj)
        {
            return await db.UpdateAsync(obj);
        }
        public virtual async Task<bool> UpdateEnumerableAsync(IEnumerable<T> list)
        {
            return await db.UpdateAsync(list);
        }

        //Delete
        public virtual bool Delete(T obj)
        {
            return db.Delete(obj);
        }
        public virtual async Task<bool> DeleteById(TKeyDataType id)
        {
            var entity = db.GetAsync<T>(id);
            if (entity == null)
                throw new Exception("Entity Not Found");
            return await db.DeleteAsync(entity);
        }
        public virtual bool DeleteEnumerable(IEnumerable<T> list)
        {
            return db.Delete(list);
        }
        public virtual bool DeleteEnumerableId(IEnumerable<TKeyDataType> list)
        {

            List<T> entityLst = new List<T>();

            Task.Run(() =>
            {

                foreach (var id in list)
                {
                    T entity = db.Get<T>(id);
                    if (entity != null)
                    {
                        entityLst.Add(entity);
                    }
                }
            });

            return db.Delete(entityLst);

        }
        public virtual bool DeleteAll()
        {
            return db.DeleteAll<T>();
        }
        public virtual async Task<bool> DeleteAsync(T entity)
        {
            return await db.DeleteAsync(entity);
        }
        public virtual async Task<bool> DeleteByIdAsync(TKeyDataType id)
        {
            var entity = db.GetAsync<T>(id);
            if (entity == null)
                throw new Exception("Entity Not Found");
            return await db.DeleteAsync(entity.Result);
        }
        public virtual async Task<bool> DeleteEnumerableAsync(IEnumerable<T> list)
        {
            return await db.DeleteAsync(list);
        }
        public virtual async Task<bool> DeleteEnumerableIdAsync(IEnumerable<TKeyDataType> list)
        {
            var entityLst = await Task.Run(() =>
            {
                List<T> entityList = new List<T>();

                foreach (var id in list)
                {
                    var entity = db.GetAsync<T>(id);
                    if (entity.Result != null)
                    {
                        entityList.Add(entity.Result);
                    }
                }

                return entityList;
            });

            return await db.DeleteAsync(entityLst);

        }
        public virtual async Task<bool> DeleteAllAsync()
        {
            return await db.DeleteAllAsync<T>();
        }


        public virtual IList<T> GetAll()
        {
            return db.GetAll<T>().ToList();
        }

        public virtual async Task<IList<T>> GetAllAsync()
        {
            var data = await db.GetAllAsync<T>();
            return data.ToList();
        }

        public virtual T GetById(TKeyDataType id)
        {
            return db.Get<T>(id);
        }

        public virtual async Task<T> GetByIdAsync(TKeyDataType id)
        {
            var data = await db.GetAsync<T>(id);
            return data;
        }

        public virtual Tuple<IEnumerable<T>, long> GetAll(SerachEntity searchEntity)
        {
            string tableName = typeof(T).Name;

            string query = CreateFindQuery(searchEntity);
            string countQuery = $"select APPROX_COUNT_DISTINCT(*) count from {tableName}";

            IEnumerable<T> resul = db.Query<T>(query);
            long count = db.QueryFirstOrDefault<long>(countQuery);

            return new Tuple<IEnumerable<T>, long>(resul, count);

        }

        public virtual async Task<Tuple<IEnumerable<T>, long>> GetAllAsync(SerachEntity searchEntity)
        {
            string tableName = "", query="", countQuery="";

            await Task.Run(() =>
            {
                tableName = typeof(T).Name;

                query = CreateFindQuery(searchEntity);
                countQuery = $"select APPROX_COUNT_DISTINCT(*) count from {tableName}";
            });

            var resul = db.QueryAsync<T>(query);
            var count = db.QueryFirstOrDefaultAsync<long>(countQuery);

            return new Tuple<IEnumerable<T>, long>(resul.Result, count.Result);
        }

        public Tuple<IEnumerable<T>, long> GetAll(int pageNumber, int pageSize)
        {
            string tableName = "", query = "", countQuery = "";
            tableName = typeof(T).Name;

            query = CreateFindQuery(pageNumber, pageSize);
            countQuery = $"select APPROX_COUNT_DISTINCT(*) count from {tableName}";

            var resul = db.Query<T>(query);
            var count = db.QueryFirstOrDefault<long>(countQuery);

            return new Tuple<IEnumerable<T>, long>(resul, count);
        }

        public async Task<Tuple<IEnumerable<T>, long>> GetAllAsync(int pageNumber, int pageSize)
        {
            string tableName = "", query = "", countQuery = "";
            await Task.Run(() =>
            {
                tableName = typeof(T).Name;

                query = CreateFindQuery(pageNumber, pageSize);
                countQuery = $"select APPROX_COUNT_DISTINCT(*) count from {tableName}";
            });


            var resul = db.QueryAsync<T>(query);
            var count = db.QueryFirstOrDefaultAsync<long>(countQuery);

            return new Tuple<IEnumerable<T>, long>(resul.Result, count.Result);
        }

        protected virtual string CreateFindQuery(int pageNumber, int pageSize)
        {
            string tableName = typeof(T).Name;
            string query = $"select * from {tableName} order by Id";


            int next = pageSize;
            int Offset = (pageNumber < 1 ? 0 : pageNumber - 1) * next;
            query += $" offset {Offset} ROWS FETCH NEXT {next} ROWS ONLY ";

            return query;
        }

        private string CreateFindQuery(SerachEntity serachEntity)
        {
            string tableName = typeof(T).Name;
            string query = $"select * from {tableName}";


            if (serachEntity != null)
            {
                string conditions = "";

                if (serachEntity.Conditions != null && serachEntity.Conditions.Count > 0)
                {


                    foreach (var condition in serachEntity.Conditions)
                    {
                        if (!string.IsNullOrWhiteSpace(conditions.Trim()))
                        {
                            conditions += " and ";
                        }

                        string operation = "";
                        string value = $"{condition.FiledValue}";

                        switch (condition.ConditionType)
                        {
                            case ConditionType.Equal:
                                if (condition.FiledValue is string || condition.FiledValue is DateTime)
                                {
                                    operation = $"=''{value}''";
                                }
                                else
                                {
                                    operation = $"={value}";
                                }

                                break;
                            case ConditionType.Great:
                                operation = $">{value}";
                                break;
                            case ConditionType.GreatThan:
                                operation = $">={value}";
                                break;
                            case ConditionType.Less:
                                operation = $"<{value}";
                                break;
                            case ConditionType.LessThan:
                                operation = $"<={value}";
                                break;
                            case ConditionType.Contains:
                                operation = $"like '%{value}%'";
                                break;

                        }

                        conditions += $"{condition.FieldName} {operation} ";
                    }

                    if (!string.IsNullOrWhiteSpace(conditions.Trim()))
                    {
                        query += $" where {conditions}";
                    }

                }


                string asc = "";

                foreach (var ascValue in serachEntity.Asc)
                {

                    if (!string.IsNullOrWhiteSpace(ascValue.Trim()))
                    {
                        if (!string.IsNullOrWhiteSpace(asc.Trim()))
                        {
                            asc += ",";
                        }
                        asc += ascValue + " asc";
                    }
                }

                foreach (var descValue in serachEntity.Desc)
                {

                    if (!string.IsNullOrWhiteSpace(descValue.Trim()))
                    {
                        if (!string.IsNullOrWhiteSpace(asc.Trim()))
                        {
                            asc += ",";
                        }
                        asc += descValue + " desc";
                    }
                }

                if (!string.IsNullOrWhiteSpace(asc.Trim()))
                {
                    query += $" order by {asc}";
                }
                int next = serachEntity.PageSize;
                int Offset = (serachEntity.PageNo < 1 ? 0 : serachEntity.PageNo - 1) * next;
                query += $" offset {Offset} ROWS FETCH NEXT {next} ROWS ONLY ";
            }

            return query;
        }
    }
}
