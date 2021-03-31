using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;

namespace BehsamFramework.DapperDomain
{
    public class QueryRepository<T>: Base.IQueryRepository<T>
        where T : Entity.IEntity
    {
        protected IDbConnection db { get; }
        protected QueryRepository(IDbConnection _db)
        {
            db = _db;
        }

        public virtual IList<T> GetAll()
        {
            return db.GetAll<T>().ToList();
        }

        public virtual async Task<IList<T>> GetAllAsync()
        {
            var data= await db.GetAllAsync<T>();
            return data.ToList();
        }

        public virtual T GetById(Guid id)
        {
            return db.Get<T>(id);
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            var data=await db.GetAsync<T>(id);
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

    public class QueryRepository<T,TKeyDataType> : Base.IQueryRepository<T,TKeyDataType>
        where T : Entity.IEntity<TKeyDataType>
        where TKeyDataType : struct
    {
        protected IDbConnection db { get; }
        protected QueryRepository(IDbConnection _db)
        {
            db = _db;
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
            string tableName="", query="", countQuery="";
            
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

        protected virtual string CreateFindQuery(SerachEntity serachEntity)
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
        protected virtual string CreateFindQuery(int pageNumber, int pageSize)
        {
            string tableName = typeof(T).Name;
            string query = $"select * from {tableName} order by Id";


            int next = pageSize;
            int Offset = (pageNumber < 1 ? 0 : pageNumber - 1) * next;
            query += $" offset {Offset} ROWS FETCH NEXT {next} ROWS ONLY ";

            return query;
        }
    }
}
