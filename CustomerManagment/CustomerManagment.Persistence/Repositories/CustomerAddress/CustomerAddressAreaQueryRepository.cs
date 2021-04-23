using CustomerManagment.Domain.Entities;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace CustomerManagment.Persistence.Repositories.CustomerAddress
{
    public class CustomerAddressAreaQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.CustomerAddressAreaInfo, long>,
        Domain.IRepository.CustomerAddress.ICustomerAddressAreaInfoQueryRepository
    {
        protected internal CustomerAddressAreaQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<CustomerAddressAreaInfo> GetByAreaAndCustomer(int areaId, long addressId)
        {
            var query = "Select * from CustomerAddressAreaInfo where AreaId=@AreaId and CustomerAddressId=@AddressId";
            var param = new
            {
                @AreaId = areaId,
                @AddressId = addressId
            };
            try
            {
                var result = await db.QueryFirstAsync<CustomerAddressAreaInfo>(query, param);
                return result;
            }
            catch
            {
                return new CustomerAddressAreaInfo();
            }
            

        }
    }
}
