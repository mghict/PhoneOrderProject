using System.Collections.Generic;
using System.Threading.Tasks;

namespace SettingManagment.Domain.IRepositories.Store
{
    public interface IStoreShippingAreaQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.StoreShippingAreaTbl, int>
    {
        Task<List<Entities.StoreShippingAreaTbl>> GetByStoreId(float storeId);
    }
}
