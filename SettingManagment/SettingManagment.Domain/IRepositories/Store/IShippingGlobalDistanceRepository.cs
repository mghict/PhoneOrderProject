using System.Threading.Tasks;

namespace SettingManagment.Domain.IRepositories.Store
{
    public interface IShippingGlobalDistanceRepository :
        BehsamFramework.DapperDomain.Base.IRepository<Entities.StoreGeneralShippingByDistanceTbl, int>
    {
        Task<int> ExistsInRangeAsync(int fromDistance, int toDistance);
    }
}
