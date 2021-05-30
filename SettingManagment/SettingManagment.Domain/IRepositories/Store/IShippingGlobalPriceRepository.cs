using System.Threading.Tasks;

namespace SettingManagment.Domain.IRepositories.Store
{
    public interface IShippingGlobalPriceRepository :
        BehsamFramework.DapperDomain.Base.IRepository<Entities.StoreGeneralShippingByPriceTbl, int>
    {
        Task<int> ExistsInRangeAsync(int fromSum, int toSum);
    }
}
