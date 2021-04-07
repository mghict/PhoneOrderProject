using BehsamFramework.DapperDomain;
using SettingManagment.Domain.IRepositories;
using SettingManagment.Domain.IRepositories.Store;
using SettingManagment.Persistence.Repositories.AttributeStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Persistence
{
    public class UnitOfWork : BehsamFramework.DapperDomain.UnitOfWork, IUnitOfWork
    {
        public UnitOfWork(Options options) : base(options)
        {
        }

        private IAttributeStatusRepository _attributeStatusRepository;
        public IAttributeStatusRepository AttributeStatusRepository =>
            _attributeStatusRepository = _attributeStatusRepository ?? new Repositories.AttributeStatus.AttributeStatusRepository(IDbConnection);

        private IStoreRepository _storeRepository;
        public IStoreRepository StoreRepository => 
            _storeRepository = _storeRepository ?? new Persistence.Repositories.Store.StoreRepository(IDbConnection);
    }
}
