using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Models;

namespace DataDapper.Repositories.CustomerPhone
{
    public class CustomerPhoneRepository : Repository<Models.CustomerPhoneTbl, long>, ICustomerPhoneRepository
    {
        private const string _getPhone= "Select * from CustomerPhoneTbl where PhoneValue=@phone and status=2;";
        private const string _getPhoneByType = "Select * from CustomerPhoneTbl where customerid=@id and phonetype=@type and status=2;";
        private const string _getCustomer = "Select a.* from CustomerInfoTbl a, CustomerPhoneTbl b where b.customerid=a.id and a.status=2 and b.status=2 and PhoneValue=@phone;";
        internal CustomerPhoneRepository(IDbConnection idbConnection) : base(idbConnection)
        {
        }

        public IEnumerable<CustomerPhoneTbl> GetPhone(long phone)
        {
            return db.Query<CustomerPhoneTbl>(_getPhone, new {@phone = phone}).AsEnumerable();
        }

        public async Task<IEnumerable<CustomerPhoneTbl>> GetPhoneAsync(long phone)
        {
            return  db.QueryAsync<CustomerPhoneTbl>(_getPhone, new { @phone = phone }).Result.AsEnumerable();
        }

        public IEnumerable<CustomerPhoneTbl> GetPhoneByType(long id, int type)
        {
            return db.Query<CustomerPhoneTbl>(_getPhoneByType, new { @id = id,@type=type }).AsEnumerable();
        }

        public async Task<IEnumerable<CustomerPhoneTbl>> GetPhoneByTypeAsync(long id, int type)
        {
            return db.QueryAsync<CustomerPhoneTbl>(_getPhoneByType, new { @id = id, @type = type }).Result.AsEnumerable();
        }

        public CustomerInfoTbl GetCustomer(long phone)
        {
            return db.Query<CustomerInfoTbl>(_getCustomer, new { @phone = phone }).SingleOrDefault();
        }

        public async Task<CustomerInfoTbl> GetCustomerAsync(long phone)
        {
            return db.QueryAsync<CustomerInfoTbl>(_getCustomer, new { @phone = phone }).Result.SingleOrDefault();
        }
    }
}
