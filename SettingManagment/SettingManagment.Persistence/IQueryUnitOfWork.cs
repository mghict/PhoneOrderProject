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
    }
}
