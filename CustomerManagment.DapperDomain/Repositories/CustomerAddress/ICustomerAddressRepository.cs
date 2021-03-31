using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDapper.Repositories.CustomerAddress
{
    public interface ICustomerAddressRepository:Base.IRepository<Models.CustomerAddressTbl,long>
    {
        IEnumerable<Models.CustomerAddressTbl> GetAddressByType(long custId,int typeId);

        Task<IEnumerable<Models.CustomerAddressTbl>> GetAddressByTypeAsync(long custId, int typeId);

        IEnumerable<Models.CustomerAddressTbl> GetAddresses(long custId);

        Task<IEnumerable<Models.CustomerAddressTbl>> GetAddressesAsync(long custId);

        IEnumerable<Models.CustomerAddressTbl> GetAddressByAreaId(long custId, int areaId);
        Task<IEnumerable<Models.CustomerAddressTbl>> GetAddressByAreaIdAsync(long custId, int areaId);
    }
}
