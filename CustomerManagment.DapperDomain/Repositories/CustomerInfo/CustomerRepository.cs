using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Models;

namespace DataDapper.Repositories.CustomerInfo
{
    public class CustomerRepository : Base.Repository<Models.CustomerInfoTbl, long>, ICustomerRepository
    {
        private const string _getByCustomerCode = "Select * from CustomerInfoTbl where CustomerCode=@Code and status=2";
        private const string _getMaxId = "SELECT NEXT VALUE FOR Customer_seq;";
        internal CustomerRepository(IDbConnection _db) : base(_db)
        {
        }

        public CustomerInfoTbl GetByCustomerCode(string customerCode)
        {
            return db.Query(_getByCustomerCode, new {@Code = customerCode}).SingleOrDefault();
        }

        public async Task<CustomerInfoTbl> GetByCustomerCodeAsync(string customerCode)
        {
            return db.QueryAsync(_getByCustomerCode, new { @Code = customerCode }).Result.SingleOrDefault();
        }

        public long GetMaxId()
        {
            return db.Query(_getMaxId).SingleOrDefault();
        }

        public async Task<long> GetMaxIdAsync()
        {
            return db.QueryAsync(_getMaxId).Result.SingleOrDefault();
        }
    }
}
