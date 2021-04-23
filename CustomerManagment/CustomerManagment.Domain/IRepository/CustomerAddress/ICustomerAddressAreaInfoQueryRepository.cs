using System.Threading.Tasks;

namespace CustomerManagment.Domain.IRepository.CustomerAddress
{
    public interface ICustomerAddressAreaInfoQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.CustomerAddressAreaInfo, long>
    {
        Task<Entities.CustomerAddressAreaInfo> GetByAreaAndCustomer(int areaId,long addressId);
    }
}
