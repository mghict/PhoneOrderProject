using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Models;

namespace DataDapper.Repositories.CustomerAddress
{
    public class CustomerAddressRepository : Repository<Models.CustomerAddressTbl, long>, ICustomerAddressRepository
    {
        private const string _getAddressByType = "Select * from CustomerAddressTbl where CustomerID=@id and AddressType =@TypeId and status=2;";
        private const string _getAddresses = "Select * from CustomerAddressTbl where CustomerID=@id and status=2;";
        private const string _getAddresseByArea = "Select * from CustomerAddressTbl where CustomerID=@id and status=2 and AreaId=@AreaId;";
        internal CustomerAddressRepository(IDbConnection idbConnection) : base(idbConnection)
        {
        }

        public IEnumerable<CustomerAddressTbl> GetAddressByType(long custId, int typeId)
        {
            return db.Query< CustomerAddressTbl>(_getAddressByType, new { @id= custId, @TypeId = typeId}).AsEnumerable();
        }

        public async Task<IEnumerable<CustomerAddressTbl>> GetAddressByTypeAsync(long custId, int typeId)
        {
            return db.QueryAsync<CustomerAddressTbl>(_getAddressByType, new { @id = custId, @TypeId = typeId }).Result.AsEnumerable();
        }

        public IEnumerable<CustomerAddressTbl> GetAddresses(long custId)
        {
            return db.Query<CustomerAddressTbl>(_getAddressByType, new {@id = custId }).AsEnumerable();
        }

        public async Task<IEnumerable<CustomerAddressTbl>> GetAddressesAsync(long custId)
        {
            return db.QueryAsync<CustomerAddressTbl>(_getAddressByType, new { @id = custId }).Result.AsEnumerable();
        }

        public IEnumerable<CustomerAddressTbl> GetAddressByAreaId(long custId, int areaId)
        {
            return db.Query<CustomerAddressTbl>(_getAddresseByArea, new { @id = custId, @AreaId = areaId }).AsEnumerable();
        }

        public async Task<IEnumerable<CustomerAddressTbl>> GetAddressByAreaIdAsync(long custId, int areaId)
        {
            return db.QueryAsync<CustomerAddressTbl>(_getAddresseByArea, new { @id = custId, @AreaId = areaId }).Result.AsEnumerable();
        }
    }
}
