﻿namespace SettingManagment.Persistence
{
    public interface IUnitOfWork : BehsamFramework.DapperDomain.Base.IUnitOfWork
    {
        Domain.IRepositories.IAttributeStatusRepository AttributeStatusRepository { get; }
        Domain.IRepositories.Store.IStoreRepository StoreRepository { get; }
        Domain.IRepositories.TimeSheet.ICustomeTimeSheetRepository CustomeTimeSheetRepository { get; }
        Domain.IRepositories.TimeSheet.ITimeSheetRepository TimeSheetRepository { get; }
        Domain.IRepositories.InActive.IStoreInActiveRepository StoreInActiveRepository { get; }
        Domain.IRepositories.InActive.IInActiveRepository InActiveRepository { get; }
        Domain.IRepositories.Area.IAreaInfoRepository AreaInfoRepository { get; }
    }
}
