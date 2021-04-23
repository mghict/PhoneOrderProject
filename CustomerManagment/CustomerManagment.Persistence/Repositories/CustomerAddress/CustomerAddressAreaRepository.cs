using System;
using System.Data;
using System.Threading.Tasks;
using CustomerManagment.Domain.Entities;
using Dapper;

namespace CustomerManagment.Persistence.Repositories.CustomerAddress
{
    public class CustomerAddressAreaRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.CustomerAddressAreaInfo, long>,
        Domain.IRepository.CustomerAddress.ICustomerAddressAreaInfoRepository
    {
        protected internal CustomerAddressAreaRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task DisableAllAsync(int areaId, long customerAddressId)
        {
            var query = "update CustomerAddressAreaInfo set Status=0 where AreaId=@AreaId and CustomerAddressId=@CustAddId";
            var param = new
            {
                @AreaId = areaId,
                @CustAddId = customerAddressId
            };

            await db.ExecuteAsync(query, param);

            return;

        }

        public async Task DisableAllAsync(long customerAddressId)
        {
            var query = "update CustomerAddressAreaInfo set Status=0 where CustomerAddressId=@CustAddId";
            var param = new
            {
                @CustAddId = customerAddressId
            };

            await db.ExecuteAsync(query, param);

            return;
        }

        public async Task EnableAsync(long id)
        {
            var query = "update CustomerAddressAreaInfo set Status=1 where Id=@id";
            var param = new
            {
                @id = id
            };

            await db.ExecuteAsync(query, param);

            return;
        }

        public async Task RemoveAllDisableAsync(int areaId, long customerAddressId)
        {
            var query = "Delete from CustomerAddressAreaInfo  where AreaId=@AreaId and CustomerAddressId=@CustAddId";
            var param = new
            {
                @AreaId = areaId,
                @CustAddId = customerAddressId
            };

            await db.ExecuteAsync(query, param);

            return;
        }

        public async Task RemoveAllDisableAsync(long customerAddressId)
        {
            var query = "Delete from CustomerAddressAreaInfo  where CustomerAddressId=@CustAddId and Status=0";
            var param = new
            {
                @CustAddId = customerAddressId
            };

            await db.ExecuteAsync(query, param);

            return;
        }

        public override async Task<CustomerAddressAreaInfo> InsertAsync(CustomerAddressAreaInfo entity)
        {
            try
            {
                var result =await base.InsertAsync(entity);
                return result;
            }
            catch(Exception ex)
            {
                return new CustomerAddressAreaInfo();
            }
        }
    }
}
