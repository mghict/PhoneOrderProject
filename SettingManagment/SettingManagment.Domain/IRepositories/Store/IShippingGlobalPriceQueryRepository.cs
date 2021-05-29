using System.Collections.Generic;
using System.Threading.Tasks;

namespace SettingManagment.Domain.IRepositories.Store
{
    public interface IShippingGlobalPriceQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.StoreGeneralShippingByPriceTbl, int>
    {
        Task<List<Entities.StoreGeneralShippingByPriceTbl>> GetByRange(int amount);
        Task<List<Entities.StoreGeneralShippingByPriceTbl>> GetByRange(int fromAmount,int toAmount);
    }
}
