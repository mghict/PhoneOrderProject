using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace SettingManagment.Domain.IRepositories.TimeSheet
{
    public interface ICustomeTimeSheetQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.StoreCustomeTimeSheetTbl, int>
    {
        Task<IList<Entities.StoreCustomeTimeSheetTbl>> GetByStoreOrDate(DateTime requestDate,float StoreId );
    }
}
