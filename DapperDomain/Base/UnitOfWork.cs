
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Base;

namespace DapperDomain.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        protected Tools.Options Options { get; set; }
        private IDbConnection _IDbConnection;

        public UnitOfWork(Tools.Options options) : base()
        {
            Options = options;
        }

        internal IDbConnection IDbConnection
        {
            get
            {
                if (_IDbConnection == null || _IDbConnection.State==ConnectionState.Closed)
                {
                    switch (Options.Provider)
                    {
                        case Tools.Enums.Provider.SqlServer:
                            {
                                _IDbConnection=new SqlConnection(Options.ConnectionString);

                                break;
                            }

                        case Tools.Enums.Provider.MySql:
                            {

                                break;
                            }

                        case Tools.Enums.Provider.Oracle:
                            {
                                _IDbConnection = new OracleConnection(Options.ConnectionString);

                                break;
                            }

                        case Tools.Enums.Provider.PostgreSQL:
                            {
                               
                                break;
                            }

                        case Tools.Enums.Provider.InMemory:
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

        public Repository<T, TKeyDataValue> GetRepository<T, TKeyDataValue>() where T : EntityBase
        {
            return new Repository<T, TKeyDataValue>(_IDbConnection);
        }


        ////***************************
        public bool IsDisposed { get; protected set; }

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

            IsDisposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
