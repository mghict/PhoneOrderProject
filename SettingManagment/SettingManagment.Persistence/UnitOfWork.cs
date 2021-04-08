﻿using BehsamFramework.DapperDomain;
using SettingManagment.Domain.IRepositories;
using SettingManagment.Domain.IRepositories.InActive;
using SettingManagment.Domain.IRepositories.Store;
using SettingManagment.Domain.IRepositories.TimeSheet;
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

        private ICustomeTimeSheetRepository _customeTimeSheetRepository;
        public ICustomeTimeSheetRepository CustomeTimeSheetRepository =>
            _customeTimeSheetRepository = _customeTimeSheetRepository ?? new Repositories.TimeSheet.CustomeTimeSheetRepository(IDbConnection);


        private ITimeSheetRepository _TimeSheetRepository;
        public ITimeSheetRepository TimeSheetRepository =>
            _TimeSheetRepository = _TimeSheetRepository ?? new Repositories.TimeSheet.TimeSheetRepository(IDbConnection);


        private IStoreInActiveRepository _StoreInActiveRepository;
        public IStoreInActiveRepository StoreInActiveRepository =>
            _StoreInActiveRepository = _StoreInActiveRepository ?? new Repositories.InActive.StoreInActiveRepository(IDbConnection);


        private IInActiveRepository _InActiveRepository;
        public IInActiveRepository InActiveRepository =>
            _InActiveRepository = _InActiveRepository ?? new Repositories.InActive.InActiveRepository(IDbConnection);
    }
}
