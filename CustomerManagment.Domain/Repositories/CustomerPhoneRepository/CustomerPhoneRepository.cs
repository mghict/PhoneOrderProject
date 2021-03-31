using DTOs.Base;
using DTOs.Results.CustomerPhone;
using Models;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class CustomerPhoneRepository : Repository<Models.CustomerPhoneTbl>, ICustomerPhoneRepository
    {
        internal CustomerPhoneRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public GetEnumerableEntity<Models.CustomerPhoneTbl> GetByCustomerId(long id)
        {
            var result=DbSet.Where(p => p.CustomerId == id && p.Status == 2);
            return new GetEnumerableEntity<Models.CustomerPhoneTbl>()
            {
                Data=result.AsEnumerable(),
                RowsCount=result.Count()
            };
        }
        public async Task<GetEnumerableEntity<Models.CustomerPhoneTbl>> GetByCustomerIdAsync(long id)
        {
            return await Task.Run(() => 
            {
                var result = DbSet.Where(p => p.CustomerId == id && p.Status == 2);
                return new GetEnumerableEntity<Models.CustomerPhoneTbl>()
                {
                    Data = result.AsEnumerable(),
                    RowsCount = result.Count()
                };
            });
        }

        public CustomerPhoneTbl GetById(long id)
        {
            return DbSet.Find(id);
        }

        public async Task<CustomerPhoneTbl> GetByIdAsync(long id)
        {
            return await DbSet.FindAsync(id);
        }

        public CustomerPhoneTbl GetByPhone(long phoneValue)
        {
            return DbSet.FirstOrDefault(p => p.PhoneValue == phoneValue);
        }

        public async Task<CustomerPhoneTbl> GetByPhoneAsync(long phoneValue)
        {
            return await Task.Run(()=>
            {
                return DbSet.FirstOrDefault(p => p.PhoneValue == phoneValue);
            });
        }
    }
}
