using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Persistence
{
    public interface IQueryUnitOfWork:BehsamFramework.DapperDomain.Base.IQueryUnitOfWork
    {
        Domain.IRepositories.IQueryCustomerValuesRepository CustomerValuesQueryRepository { get; }
        Domain.IRepositories.TimeSheet.ITimeSheetQueryRepository TimeSheetQueryRepository { get; }
        Domain.IRepositories.Store.IStoreQueryRepository StoreQueryRepository { get; }
        Domain.IRepositories.Category.ICategoryQueryRepository CategoryQueryRepository { get; }
        Domain.IRepositories.Product.IProductQueryRepository ProductQueryRepository { get; }
        Domain.IRepositories.TimeSheet.ICustomeTimeSheetQueryRepository CustomeTimeSheetQueryRepository { get; }
        Domain.IRepositories.InActive.IInActiveQueryRepository InActiveQueryRepository { get; }
        Domain.IRepositories.InActive.IStoreInActiveQueryRepository StoreInActiveQueryRepository { get; }
        Domain.IRepositories.Area.IAreaInfoQueryRepository AreaInfoQueryRepository { get; }
        Domain.IRepositories.Area.IProvinceQueryRepository ProvinceQueryRepository { get; }
        Domain.IRepositories.Area.ICityQueryRepository CityQueryRepository { get; }
        Domain.IRepositories.Area.IAreaGeoQueryRepository AreaGeoQueryRepository { get; }
        Domain.IRepositories.Store.IStoreShippingAreaQueryRepository StoreShippingAreaQueryRepository { get; }
        Domain.IRepositories.Store.IStoreShippingQueryRepository StoreShippingQueryRepository { get; }
    }
}
