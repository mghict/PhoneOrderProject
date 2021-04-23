using System.Threading.Tasks;

namespace CustomerManagment.Domain.IRepository.CustomerAddress
{
    public interface ICustomerAddressAreaInfoRepository :
        BehsamFramework.DapperDomain.Base.IRepository<Entities.CustomerAddressAreaInfo, long>
    {
        Task DisableAllAsync(int areaId, long customerAddressId);
        Task DisableAllAsync(long customerAddressId);
        Task EnableAsync(long id);
        Task RemoveAllDisableAsync(int areaId, long customerAddressId);
        Task RemoveAllDisableAsync(long customerAddressId);
    }
}
