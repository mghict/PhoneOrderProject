using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SettingManagment.Domain.IRepositories.Store
{
    public interface IStoreQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.Stores, float>
    {
        Task<IList<Entities.Stores>> GetStoresAsync(DateTime requestDate, TimeSpan start, TimeSpan end, long customerId);
    }
}
