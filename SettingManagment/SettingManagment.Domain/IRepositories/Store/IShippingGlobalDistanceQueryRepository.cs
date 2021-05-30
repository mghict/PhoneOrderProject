using System.Collections.Generic;
using System.Threading.Tasks;

namespace SettingManagment.Domain.IRepositories.Store
{
    public interface IShippingGlobalDistanceQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.StoreGeneralShippingByDistanceTbl, int>
    {
        Task<List<Entities.StoreGeneralShippingByDistanceTbl>> GetByRange(int distance);
        Task<List<Entities.StoreGeneralShippingByDistanceTbl>> GetByRange(int fromDistance, int toDistance);
    }
}
