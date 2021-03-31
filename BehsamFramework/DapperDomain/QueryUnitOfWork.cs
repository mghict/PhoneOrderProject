using System;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using BehsamFramework.Attributes.Authorize.Persistence;
using MySql.Data.MySqlClient;
using Npgsql;
using BehsamFramework.DapperDomain;

namespace BehsamFramework.DapperDomain
{
    public abstract class QueryUnitOfWork : Base.IQueryUnitOfWork
    {
        protected Options Options { get; set; }
        public QueryUnitOfWork(Options options) : base()
        {
            Options = options;
        }

        private IDbConnection _IDbConnection;
        protected IDbConnection IDbConnection
        {
            get
            {
                if (_IDbConnection == null || _IDbConnection.State == ConnectionState.Closed)
                {
                    switch (Options.Provider)
                    {
                        case Enums.Provider.SqlServer:
                            {
                                _IDbConnection = new SqlConnection(Options.ConnectionString);

                                break;
                            }

                        case Enums.Provider.MySql:
                            {
                                _IDbConnection = new MySqlConnection(Options.ConnectionString);
                                break;
                            }

                        case Enums.Provider.Oracle:
                            {
                                _IDbConnection = new OracleConnection(Options.ConnectionString);
                                break;
                            }

                        case Enums.Provider.PostgreSQL:
                            {
                                _IDbConnection = new NpgsqlConnection(Options.ConnectionString);
                                break;
                            }

                        case Enums.Provider.InMemory:
                            {
                                //optionsBuilder.UseInMemoryDatabase(databaseName: "Temp");

                                break;
                            }

                        default:
                            {
                                break;
                            }
                    }
                }

                return _IDbConnection;
            }
        }


        ////***************************
        public bool IsDisposed { get; protected set; }

        private UserRepository _authorizeRepository;

        public UserRepository AuthorizeRepository =>
            _authorizeRepository = _authorizeRepository ?? new UserRepository(_IDbConnection);

        public void Dispose()
        {
            Dispose(true);

            System.GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed)
            {
                return;
            }

            if (disposing)
            {
                // TODO: dispose managed state (managed objects).

                if (_IDbConnection != null)
                {
                    try
                    {
                        if (_IDbConnection.State != ConnectionState.Closed)
                            _IDbConnection.Close();
                    }
                    catch
                    { }
                    finally
                    {
                        _IDbConnection.Dispose();
                        _IDbConnection = null;
                    }

                }
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            IsDisposed = true;
        }

        /*void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }*/

        ~QueryUnitOfWork()
        {
            Dispose(false);
        }

    }
}