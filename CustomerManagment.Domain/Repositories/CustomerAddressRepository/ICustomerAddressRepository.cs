using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface ICustomerAddressRepository : Base.IRepository<Models.CustomerAddressTbl>
    {
        Models.CustomerAddressTbl GetById(long Id);
        Task<Models.CustomerAddressTbl> GetByIdAsync(long Id);
        DTOs.Base.GetEnumerableEntity<Models.CustomerAddressTbl> GetByCustomerId(long customerId);
        DTOs.Base.GetEnumerableEntity<Models.CustomerAddressTbl> GetByAddressType(int addressType);
        DTOs.Base.GetEnumerableEntity<Models.CustomerAddressTbl> GetByAddressType(int addressType,int PageNo,int PageSize);
        DTOs.Base.GetEnumerableEntity<Models.CustomerAddressTbl> GetByCustomerIdWithAddressType(long customerId,int addressType);
        DTOs.Base.GetEnumerableEntity<Models.CustomerAddressTbl> GetByCustomerIdWithAddressType(long customerId, int addressType,int PageNo,int PageSize);
        DTOs.Base.GetEnumerableEntity<Models.CustomerAddressTbl> GetByCustomerIdWithAreaId(long customerId, int areaId);
        DTOs.Base.GetEnumerableEntity<Models.CustomerAddressTbl> GetByCustomerIdWithAreaId(long customerId, int areaId, int PageNo, int PageSize);

        Task<DTOs.Base.GetEnumerableEntity<Models.CustomerAddressTbl>> GetByCustomerIdAsync(long customerId);
        Task<DTOs.Base.GetEnumerableEntity<Models.CustomerAddressTbl>> GetByAddressTypeAsync(int addressType);
        Task<DTOs.Base.GetEnumerableEntity<Models.CustomerAddressTbl>> GetByAddressTypeAsync(int addressType, int PageNo, int PageSize);
        Task<DTOs.Base.GetEnumerableEntity<Models.CustomerAddressTbl>> GetByCustomerIdWithAddressTypeAsync(long customerId, int addressType);
        Task<DTOs.Base.GetEnumerableEntity<Models.CustomerAddressTbl>> GetByCustomerIdWithAddressTypeAsync(long customerId, int addressType, int PageNo, int PageSize);
        Task<DTOs.Base.GetEnumerableEntity<Models.CustomerAddressTbl>> GetByCustomerIdWithAreaIdAsync(long customerId, int areaId);
        Task<DTOs.Base.GetEnumerableEntity<Models.CustomerAddressTbl>> GetByCustomerIdWithAreaIdAsync(long customerId, int areaId, int PageNo, int PageSize);
    }
}
