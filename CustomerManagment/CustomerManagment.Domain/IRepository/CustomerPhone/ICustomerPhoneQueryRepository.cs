using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagment.Domain.IRepository.CustomerPhone
{
    public interface ICustomerPhoneQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.CustomerPhoneTbl, long>
    {
        Task<ICollection<Domain.Entities.CustomerPhoneTbl>> GetCustomerPhonesAsync(long id);
        Task<Entities.CustomerPhoneTbl> GetByPhoneAsync(long phoneId);
    }
}