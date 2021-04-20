using System.Threading.Tasks;

namespace SettingManagment.Domain.IRepositories.Store
{
    public interface IStoreShippingQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.StoreShippingTbl, int>
    {
        Task<Entities.StoreShippingTbl> GetByStoreId(float storeId);
    }
}
