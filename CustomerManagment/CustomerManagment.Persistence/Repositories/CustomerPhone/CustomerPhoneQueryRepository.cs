using CustomerManagment.Domain.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Persistence.Repositories.CustomerPhone
{
    public class CustomerPhoneQueryRepository:
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.CustomerPhoneTbl,long>,
        Domain.IRepository.CustomerPhone.ICustomerPhoneQueryRepository
    {
        protected internal CustomerPhoneQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<ICollection<Domain.Entities.CustomerPhoneTbl>> GetCustomerPhonesAsync(long id)
        {

                string query = "select * from CustomerPhoneTbl where CustomerID=@CustomerID";
                var entity =await db.QueryAsync<CustomerPhoneTbl>(query, new { @CustomerID = id });

                return entity.ToList();

        }
        public async Task<CustomerPhoneTbl> GetByPhoneAsync(long phoneId)
        {
            var query = "Select *  FROM dbo.CustomerPhoneTbl where PhoneValue=@phone ;";

            var entity = await db.QueryFirstAsync<CustomerPhoneTbl>(query, new { @phone = phoneId });

            return entity;
        }
    }
}
