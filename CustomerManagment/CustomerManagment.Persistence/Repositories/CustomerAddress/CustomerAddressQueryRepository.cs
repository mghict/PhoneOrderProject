using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagment.Domain.Entities;
using Dapper;

namespace CustomerManagment.Persistence.Repositories.CustomerAddress
{
    public class CustomerAddressQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.CustomerAddressTbl, long>,
        Domain.IRepository.CustomerAddress.ICustomerAddressQueryRepository
    {
        protected internal CustomerAddressQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<ICollection<CustomerAddressTbl>> GetCustomerAddressAsync(long id)
        {
            string query = "select a.*,b.AreaName  from CustomerAddressTbl a,AreaInfoTbl b where a.CustomerID=@CustomerID and a.AreaID=b.ID ;";
            var entity = await db.QueryAsync<CustomerAddressTbl>(query, new { @CustomerID = id });

            return entity.ToList();
        }
    }
}