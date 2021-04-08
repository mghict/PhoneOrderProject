using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SettingManagment.Domain.IRepositories.InActive
{
    public interface IStoreInActiveQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Domain.Entities.StoreInActiveTbl, int>
    {
        Task<IList<Domain.Entities.StoreInActiveTbl>> GetByStoreId(float storeId);
        Task<IList<Domain.Entities.StoreInActiveTbl>> GetByDate(DateTime startDate);

        Task<IList<Domain.Entities.StoreInActiveTbl>> GetByStoreAndDate(DateTime startDate, float storeId);
    }
}
